using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPatio : MonoBehaviour
{

    public GameObject[] listaCamaras;
                int     numeroCamaras = 3;



    void Start()
    {
        //ApagarCamaras();
        listaCamaras[0].gameObject.SetActive(true); //activa manualmente la camara 1
    }


    public void ApagarCamaras()
    {
        for (int i = 0; i < numeroCamaras; i++) //recorre el array de camaras 
        {
            listaCamaras[i].gameObject.SetActive(false); //desactiva todas y cada una 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
         

        if (other.gameObject.tag == "Player") //si el jugador entra en el collider 
        {

            for (int i = 0; i < numeroCamaras; i++) //recorre el array de camaras 
            {
                listaCamaras[i].gameObject.SetActive(false); //desactiva todas y cada una 
            }

                listaCamaras[2].gameObject.SetActive(true); //Camara del patio
        }
    }

    public void OnTriggerExit(Collider other)
    {


        if (other.gameObject.tag == "Player") //si el jugador entra en el collider 
        {

            for (int i = 0; i < numeroCamaras; i++) //recorre el array de camaras 
            {
                listaCamaras[i].gameObject.SetActive(false); //desactiva todas y cada una 
            }

            listaCamaras[0].gameObject.SetActive(true);
        }
    }
}
