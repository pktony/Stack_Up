using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    public GameObject stack = null;
    private GameObject bottomStack = null;
    private GameObject currentStack = null;
    public Transform stackParent = null;

    float sizeDiff = 0.0f;
    Vector3 scaleChange = Vector3.zero;

    private float stackHeight = 0.5f;
    public bool spawnPosition_Forward = true;

    private void Awake()
    {
        bottomStack = FindObjectOfType<Ground>().gameObject;
        currentStack = Instantiate(stack, stackParent);
        currentStack.transform.position = this.transform.position;

        spawnPosition_Forward = true;
    }
    /// <summary>
    /// Stack 위치에 따른 크기 변경
    /// </summary>
    public void CalculateSize()
    {
        if (spawnPosition_Forward)
        {
            sizeDiff = bottomStack.transform.position.z - currentStack.transform.position.z;
            scaleChange = new Vector3(0, 0, sizeDiff);
            HowExact(bottomStack.transform.localScale.z);
        }
        else
        { 
            sizeDiff =  bottomStack.transform.position.x - currentStack.transform.position.x;
            scaleChange = new Vector3(sizeDiff, 0, 0);
            HowExact(bottomStack.transform.localScale.x);
        }
    }

    void HowExact(float bottomLocalScale)
    {
        if (sizeDiff < -0.1 && sizeDiff > -bottomLocalScale)
        {
            currentStack.transform.localScale += scaleChange;
            currentStack.transform.position += scaleChange * 0.5f;
            GameManager.Inst.Score++;
        }
        else if (sizeDiff > 0.1 && sizeDiff < bottomLocalScale) //지나쳤다.
        {
            currentStack.transform.localScale -= scaleChange;
            currentStack.transform.position += scaleChange * 0.5f;
            GameManager.Inst.Score++;
        }
        else if (Mathf.Abs(sizeDiff) <= 0.1) //정확했다.
        {
            Debug.Log("정확했다.");
            GameManager.Inst.Score++;
        }
        else if (Mathf.Abs(sizeDiff) >= bottomLocalScale) // 완전 벗어낫다
        {
            Debug.Log("GameOver");
            GameManager.Inst.IsGameover = true;
            GameManager.Inst.onGameover?.Invoke();
        }
    }

    public void OnNextFloor()
    {
        CalculateSize();

        if (!GameManager.Inst.IsGameover)
        {
            bottomStack = currentStack;

            if (spawnPosition_Forward)
            {
                //transform.position += transform.up * stackHeight;  //transform.up * stackHeight + transform.forward * 8.0f - transform.right * 8.0f ;
                transform.position = new Vector3(-8.0f, stackHeight * GameManager.Inst.Score, bottomStack.transform.position.z);
            }
            else
            {
                //transform.position += new Vector3(8.0f - bottomStack.transform.position.x, stackHeight, -8.0f);
                transform.position = new Vector3(bottomStack.transform.position.x, stackHeight * GameManager.Inst.Score, 8.0f);
            }
            spawnPosition_Forward = !spawnPosition_Forward;

            currentStack = Instantiate(stack, stackParent);
            currentStack.transform.localScale = bottomStack.transform.localScale;
            currentStack.transform.position = this.transform.position;
        }
    }
}
