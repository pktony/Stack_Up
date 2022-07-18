using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText = null;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameManager.Inst.onScoreUp += UpdateScore;
    }

    private void UpdateScore()
    {
        scoreText.text = $"{GameManager.Inst.Score}".ToString();
    }
}
