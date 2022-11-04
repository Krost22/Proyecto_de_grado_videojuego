using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public GameObject camera1;
    public GameObject camera2;

    private void Start()
    {
        camera1 = GameObject.Find("Camera1");
        camera2 = GameObject.Find("Camera2");

        camera2.SetActive(false);
        camera1.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Cuando el jugador entre en el collider se activará
        //Cambiará a la segunda camara - PD: modificar el script para que elimine las camaras sobrantes sin utilizar

        if (other.gameObject.tag == "Player")
        {
            SwitchToCamera2();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //Si sale del collider activa la camara 1 y desactiva la camara 2

        if (other.gameObject.tag == "Player")
        {
            SwitchToCamera1();
        }
    }

    private void SwitchToCamera2()
    {
        camera2.SetActive(true); //activa la camara 2
        camera1.SetActive(false);//desactiva la camara 1
    }

    private void SwitchToCamera1()
    {
        camera2.SetActive(false);
        camera1.SetActive(true);
    }
}

