using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Inst { get => instance; }

    private readonly float followHeight = 0.5f;
    private int score = 0;

    public Action onScoreUp;
    public Action onGameover;
    public int Score 
    { 
        get => score;
        set 
        { 
            score = value;
            onScoreUp?.Invoke();
            if (score > 2)
            {
                Camera.main.transform.position += transform.up * followHeight;
            }
        } 
    }

    private bool isGameover = false;
    public bool IsGameover { get => isGameover; 
        set
        { 
            isGameover = value;
            if (IsGameover)
            {
                onGameover?.Invoke();
            }
        }
    }

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
        isGameover = true;
        score = 0;
    }
}
