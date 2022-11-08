using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //¡¡¡ DEMASIADAS CAMARAS !!!

    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    public GameObject patioCollider;
    public GameObject casaCollider;

    

    private void Start()
    {
        camera1 = GameObject.Find("Camera1");
        camera2 = GameObject.Find("Camera2");
        camera3 = GameObject.Find("Camera3");

        patioCollider = GameObject.Find("patioCollider");
        casaCollider = GameObject.Find("casaCollider");

        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);

        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Cuando el jugador entre en el collider se activará
        //Cambiará a la segunda camara - PD: modificar el script para que elimine las camaras sobrantes sin utilizar

        if (GameObject.Find("casaCollider") && other.gameObject.tag == "Player")
        {
            SwitchToCamera2();
        }
        if (GameObject.Find("patioCollider") && other.gameObject.tag == "Player")
        {
            SwitchToCamera3();
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            SwitchToCamera1();
        }
    }
    
    private void SwitchToCamera1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
    }

    private void SwitchToCamera2()
    {
        camera1.SetActive(false);//desactiva la camara 1
        camera2.SetActive(true); //activa la camara 2
        camera3.SetActive(false);
    }

    private void SwitchToCamera3()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(true);
    }
}

