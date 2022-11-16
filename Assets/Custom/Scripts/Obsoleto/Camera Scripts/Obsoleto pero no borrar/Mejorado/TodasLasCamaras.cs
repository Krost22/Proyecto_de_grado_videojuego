using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodasLasCamaras : MonoBehaviour
{

    public GameObject[] listaCamaras;

    string CameraTag = "Camera";
    string MainCameraTag = "MainCamera";

    public void ApagarCamaras()
    {
        foreach (var c in listaCamaras)
        {
            c.tag = CameraTag;
        }

        for (int i = 0; i < listaCamaras.Length; i++) //recorre el array de camaras 
        {
            listaCamaras[i].gameObject.SetActive(false); //desactiva todas y cada una 
        }
    }

    public void CambioTag()
    {
        
        
        foreach (var c in listaCamaras)
        {
            GameObject.FindGameObjectsWithTag("Camera");

            c.tag = MainCameraTag;
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    private void Awake()
    {
            
    }

    // Start is called before the first frame update
    void Start()
    {   
        listaCamaras[0] = GameObject.Find("Camera1");
        listaCamaras[1] = GameObject.Find("Camera2");
        listaCamaras[2] = GameObject.Find("Camera3");


        ApagarCamaras();
        listaCamaras[0].gameObject.SetActive(true); //activa manualmente la camara 1

        CambioTag();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
