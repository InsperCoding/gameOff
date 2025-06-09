using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        // Obtém o score atualizado da classe ScoreManager
        int score = ScoreManager.score;
        UpdateScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza o texto do score a partir do valor atualizado em ScoreManager
        UpdateScoreText(ScoreManager.score);
    }

    public void AddScore(int pts)
    {
        // Adiciona pontos ao score
        ScoreManager.score += pts;
    }

    private void UpdateScoreText(int score)
    {
        // Atualiza o texto com o valor do score
        text.text = String.Format("Score: {0}", score);
    }
}
