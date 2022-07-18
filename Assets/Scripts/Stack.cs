using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stack : MonoBehaviour
{
    StackAction input = null;
    StackSpawner spawner = null;
    MeshRenderer meshRender = null;

    [SerializeField] private float moveSpeed = 3.0f;
    private readonly float stackSize = 5.0f;

    private void Awake()
    {
        input = new();
        spawner = FindObjectOfType<StackSpawner>();
        meshRender = GetComponent<MeshRenderer>();

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
            transform.position += Time.deltaTime * moveSpeed * -transform.forward;
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
            //Debug.Log(GameManager.Inst.Score);

            Destroy(this);
        }
    }
}
