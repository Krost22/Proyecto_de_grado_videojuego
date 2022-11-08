using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTA: No se puede tener más de una camara activa

public class CambioCamara : MonoBehaviour
{
    //Declaracion de variables
    public GameObject[] listaCamaras;
    public int numeroCamaras = 3;

   


    public void ApagarCamaras()
    {
        for (int i = 0; i < numeroCamaras; i++) //recorre el array de camaras 
        {
            listaCamaras[i].gameObject.SetActive(false); //desactiva todas y cada una 
        }       
    }

    // Start is called before the first frame update
    void Start()
    {
         ApagarCamaras();
         listaCamaras[0].gameObject.SetActive(true); //activa manualmente la camara 1
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Tecla 1 presionada");
            //desactivamos todas las camaras con un bucle for que las recorre
            ApagarCamaras();

            //activamos la camara que queremos
            listaCamaras[0].gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Tecla 2 presionada");
            //desactivamos todas las camaras con un bucle for que las recorre
            ApagarCamaras();

            //activamos la camara que queremos
            listaCamaras[1].gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Tecla 3 presionada");
            //desactivamos todas las camaras con un bucle for que las recorre
            ApagarCamaras();

            //activamos la camara que queremos
            listaCamaras[2].gameObject.SetActive(true);
        }
    }
}
