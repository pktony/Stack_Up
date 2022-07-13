using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSpawner_Forward : MonoBehaviour
{
    public GameObject stack_Forward = null;
    private GameObject bottomStack = null;
    private GameObject currentStack = null;

    float sizeDiff = 0.0f;
    Vector3 scaleChange = Vector3.zero;

    private float stackHeight = 0.5f;

    private void Awake()
    {
        bottomStack = FindObjectOfType<Ground>().gameObject;
        currentStack = Instantiate(stack_Forward);
        currentStack.transform.position = this.transform.position;
    }

    /// <summary>
    /// Stack ��ġ�� ���� ũ�� ����
    /// </summary>
    public void CalculateSize()
    {
        sizeDiff = bottomStack.transform.position.z - currentStack.transform.position.z;
        Debug.Log(sizeDiff);

        HowExact();
    }

    void HowExact()
    {
        //stack[0] = �� , stack[1] = �߾�, stack[2] = ��
        if (sizeDiff < -0.1 && sizeDiff > -5.0f) // ������.
        {
            scaleChange = new Vector3(0, 0, sizeDiff);
            currentStack.transform.GetChild(1).localScale += scaleChange;
            currentStack.transform.GetChild(1).position += scaleChange * 0.5f;

            currentStack.transform.GetChild(2).gameObject.SetActive(true);
            currentStack.transform.GetChild(2).localScale -= new Vector3(0f, 0f, 5f) - scaleChange;
            currentStack.transform.GetChild(2).position += scaleChange;
            GameManager.Inst.Score++;
        }
        else if (sizeDiff > 0.1 && sizeDiff < 5.0f) //�����ƴ�.
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
        else if (Mathf.Abs(sizeDiff) >= 5.0f) // ���� �����
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

            transform.position = new Vector3(-8.0f, stackHeight * GameManager.Inst.Score, bottomStack.transform.position.z);

            currentStack = Instantiate(stack_Forward);
            currentStack.transform.localScale = bottomStack.transform.localScale;
            currentStack.transform.position = this.transform.position;
        }
    }
}
