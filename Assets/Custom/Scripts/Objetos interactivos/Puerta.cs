using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("Puerta") && other.gameObject.tag == "Player")
        {
            Debug.Log("Te falta una llave");
        }
    }
}