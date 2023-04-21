using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    public Text ScoreTextSombra;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
        ScoreTextSombra.text = ScoreText.text;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
