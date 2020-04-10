using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer:MonoBehaviour {
    [SerializeField] AudioClip themeAudioClip;
    [SerializeField] AudioClip gameplayAudioClip;

    private AudioSource musicSource;
    private double volumeGoal;

    void Awake() {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start() {
        PlayThemeMusic();
    }

    // Update is called once per frame
    void Update() {

    }

    private void PlayThemeMusic() {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 1;
        musicSource.pitch = 1;
        volumeGoal = 1;
        musicSource.PlayOneShot(themeAudioClip);
    }
}
