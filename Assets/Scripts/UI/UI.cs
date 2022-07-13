using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    StackAction input = null;

    GameObject startButton = null;
    GameObject gameover_Text = null;
    GameObject restartButton = null;

    Scene playScene;

    private void Awake()
    {
        input = new();

        startButton = transform.Find("Start").gameObject;
        gameover_Text = transform.Find("Gameover").gameObject;
        restartButton = transform.Find("Restart").gameObject;

        playScene = SceneManager.GetSceneByBuildIndex(0);
    }

    private void Start()
    {
        GameManager.Inst.onGameover += OnGameover;
    }

    private void OnEnable()
    {
        input.Stack.Enable();
        input.Stack.Start.performed += OnGameStart;
    }

    public void OnGameStart(InputAction.CallbackContext _)
    {
        startButton.SetActive(false);

        GameManager.Inst.IsGameover = false;
    }

    void OnGameover()
    {
        gameover_Text.SetActive(true);
        restartButton.SetActive(true);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(playScene.buildIndex);
    }
}
