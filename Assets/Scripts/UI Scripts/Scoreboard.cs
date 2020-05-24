using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard: MonoBehaviour {

    private int score;
    private Text objText;

    // Start is called before the first frame update
    void Start() {
        InitiateScoreboard();
    }

    // Update is called once per frame
    void Update() {

    }

    private void InitiateScoreboard() {
        objText = GetComponent<Text>();
        score = 0;
        objText.text = score.ToString();
    }

    public void ScoreHit(int scoreToAdd) {
        score += scoreToAdd;
        objText.text = score.ToString();
    }
}
