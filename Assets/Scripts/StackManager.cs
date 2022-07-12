using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    //private static StackManager instance = null;
    //public static StackManager Inst { get => instance; }

    //public Queue<GameObject> stacks;
    //public GameObject stack = null;
    

    //private int stackNum = 10;
    //private float stackHeight = 0.5f;

    //public float StackHeight { get => stackHeight; }
    //public float StackNum { get => stackNum; }

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //        instance.Initialize();
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    //private void Initialize()
    //{
    //    stacks = new Queue<GameObject>();

    //    for (int i = 0; i < stackNum; i++)
    //    {
    //        GameObject tmp = Instantiate(stack, this.gameObject.transform);
    //        tmp.SetActive(false);
    //        stacks.Enqueue(tmp);
    //    }
    //}

    //public GameObject GetPooledStack()
    //{
    //    if (stacks.Count > 0)
    //    {
    //        GameObject obj = stacks.Dequeue();
    //        obj.SetActive(true);
    //        return obj;
    //    }
    //    return null;
    //}

    //public void ReturnStack(GameObject uselessStack)
    //{
    //    uselessStack.SetActive(false);
    //    stacks.Enqueue(uselessStack);
    //}
    
}
