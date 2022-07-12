using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 initialPosition = new Vector3(6.0f, 5.0f, -6.0f);
    Vector3 initialRotation = new Vector3(30.0f, -45.0f, 0.0f);


    private void Awake()
    {
        this.transform.position = initialPosition;
        this.transform.rotation = Quaternion.Euler(initialRotation);
    }


}
