using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void FixedUpdate()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }
}
