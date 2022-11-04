using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform target;
    public Transform personaje;
    public float speed = 1;
    public float offset;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(personaje);
        transform.position = Vector3.Lerp(transform.position, target.position, speed * 2f);
    }
}
