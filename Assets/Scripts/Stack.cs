using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stack : MonoBehaviour
{
    StackAction input = null;
    StackSpawner spawner = null;

    [SerializeField] private float moveSpeed = 3.0f;
    private float stackSize = 5.0f;

    private void Awake()
    {
        input = new();
        spawner = FindObjectOfType<StackSpawner>();

        this.transform.localScale = new Vector3(stackSize, 0.5f, stackSize);
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
        if (spawner.spawnPosition_Forward)
        {
            transform.position += Time.deltaTime * moveSpeed * -transform.forward; //Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * stackSpeed);
        }
        else
        {
            transform.position += Time.deltaTime * moveSpeed * transform.right;
        }
    }

    void OnStopInput(InputAction.CallbackContext _)
    {
        if (!GameManager.Inst.IsGameover)
        {
            moveSpeed = 0f;
            spawner.OnNextFloor();
            Debug.Log(GameManager.Inst.Score);

            Destroy(this);
        }
    }
}
