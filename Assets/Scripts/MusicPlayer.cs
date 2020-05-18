using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for scene detection only

public class MusicPlayer: MonoBehaviour {
    [SerializeField] AudioClip themeAudioClip;
    [SerializeField] AudioClip gameplayAudioClip;

    private AudioSource musicSource;
    private double volumeGoal;
    private string currentSceneName;

    void Awake() {
        SetSingleton();
    }

    // Start is called before the first frame update
    void Start() {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 1;
        musicSource.pitch = 1;

        PlayLevelMusic();
    }

    // Update is called once per frame
    void Update() {
        DetectSceneChange();
    }

    private void SetSingleton() {
        if(FindObjectsOfType<MusicPlayer>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(this);
        }
    }

    private void DetectSceneChange() {
        if(SceneManager.GetActiveScene().name != currentSceneName) {
            musicSource.Stop();
            PlayLevelMusic();
        }
    }

    private void PlayLevelMusic() {
        currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "Menu") {
            PlayThemeMusic();
        } else {
            PlayGameMusic();
        }
    }

    private void PlayThemeMusic() {
        musicSource.clip = themeAudioClip;
        musicSource.Play();
    }

    private void PlayGameMusic() {
        musicSource.clip = gameplayAudioClip;
        musicSource.Play();
    }

    private void StopMusic() {
        musicSource.Stop();
    }
}
