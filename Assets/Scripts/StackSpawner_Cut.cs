using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSpawner_Cut : MonoBehaviour
{
    public GameObject stack = null;
    private GameObject bottomStack = null;
    private GameObject currentStack = null;

    public GameObject test = null;

    float sizeDiff = 0.0f;
    Vector3 scaleChange = Vector3.zero;

    private float stackHeight = 0.5f;
    public bool spawnPosition_Forward = true;

    private void Awake()
    {
        bottomStack = FindObjectOfType<Ground>().gameObject;
        currentStack = FindObjectOfType<Stack>().gameObject;
        currentStack.transform.position = this.transform.position;

        spawnPosition_Forward = true;
    }

    /// <summary>
    /// Stack ��ġ�� ���� ũ�� ����
    /// </summary>
    public void CalculateSize()
    {
        if (spawnPosition_Forward)
        {

            //sizeDiff = bottomStack.transform.position.z - currentStack.transform.position.z;
            //scaleChange = new Vector3(0, 0, sizeDiff);
        }
        else
        { 
            //sizeDiff =  bottomStack.transform.position.x - currentStack.transform.position.x;
            //scaleChange = new Vector3(sizeDiff, 0, 0);
        }
        Debug.Log(sizeDiff);

        if (sizeDiff < -0.1 && sizeDiff > -5.0f)
        {
            currentStack.transform.localScale += scaleChange;
            currentStack.transform.position += scaleChange * 0.5f;
            GameManager.Inst.Score++;
        }
        else if(sizeDiff > 0.1 && sizeDiff < 5.0f) //�����ƴ�.
        {
            currentStack.transform.localScale -= scaleChange;
            currentStack.transform.position += scaleChange * 0.5f;
            GameManager.Inst.Score++;
        }
        else if (Mathf.Abs(sizeDiff) <= 0.1) //��Ȯ�ߴ�.
        {
            Debug.Log("��Ȯ�ߴ�.");
            GameManager.Inst.Score++;
        }
        else if ( Mathf.Abs(sizeDiff) >= 5.0f) // ���� �����
        {
            Debug.Log("GameOver");
            GameManager.Inst.IsGameover = true;
            GameManager.Inst.Score++;
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

            currentStack = Instantiate(stack);
            currentStack.transform.localScale = bottomStack.transform.localScale;
            currentStack.transform.position = this.transform.position;
        }
    }
}
