using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Player").GetComponent<PlayerHealth>().score;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = String.Format("Score:{0}",score);
        GameObject.Find("Player").GetComponent<PlayerHealth>().score = score;
        //score++;
    }

    public void AddScore(int pts)
    {
        Debug.Log("PINTO");
        score += pts;
    }
}
