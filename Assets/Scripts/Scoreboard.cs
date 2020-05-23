﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard: MonoBehaviour {

    private int score;
    private Text scoreText;

    // Start is called before the first frame update
    void Start() {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ScoreHit(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
}
