using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Inst { get => instance; }

    private float followHeight = 0.5f;
    private int score = 0;
    public int Score 
    { 
        get => score;
        set 
        { 
            score = value; 

            if (score > 2)
            {
                Camera.main.transform.position += transform.up * followHeight;
            }
        } 
    }

    private bool isGameover = false;
    public bool IsGameover { get => isGameover; set { isGameover = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            instance.Initialize();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Initialize()
    {
        isGameover = false;
        score = 0;
    }
}
