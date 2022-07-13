using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stack_Forward : MonoBehaviour
{
    StackAction input = null;
    StackSpawner_Forward spawner = null;

    [SerializeField] private float moveSpeed = 3.0f;

    private void Awake()
    {
        input = new();
        spawner = FindObjectOfType<StackSpawner_Forward>();
    }

    private void OnEnable()
    {
        input.Stack.Enable();
        input.Stack.Stop.performed += OnStopInput;
    }

    private void OnDisable()
    {
        input.Stack.Stop.performed -= OnStopInput;
        input.Stack.Disable();
    }

    private void Update()
    {
        if (!GameManager.Inst.IsGameover)
        {
            Move();
        }
    }
    void Move()
    {
        transform.position += Time.deltaTime * moveSpeed * -transform.forward;
    }

    void OnStopInput(InputAction.CallbackContext _)
    {
        moveSpeed = 0f;
        spawner.OnNextFloor();
        //Debug.Log(GameManager.Inst.Score);

        Destroy(this);
    }
}
