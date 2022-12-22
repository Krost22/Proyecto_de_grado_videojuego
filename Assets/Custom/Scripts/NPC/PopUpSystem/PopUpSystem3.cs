using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem3 : MonoBehaviour
{

    Collider m_Collider;
    Canvas CanvasNpc;
    Canvas pressE;
    bool canvasEnable;

    public float sphereRadius = 0.5f;
    public float sphereLenght = 5f;

    public LayerMask detectLayers;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.SphereCast(ray, sphereRadius, out hit, sphereLenght, detectLayers))
        {
            CanvasNpc = hit.transform.Find("CanvasNpc").GetComponent<Canvas>();
            pressE = hit.transform.Find("Press E").GetComponent<Canvas>();

            pressE.enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && canvasEnable == false)
            {
                CanvasNpc.enabled = true;
                canvasEnable = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && canvasEnable == true)
            {
                CanvasNpc.enabled = false;
                canvasEnable = false;
            }
        }

        else if(!Physics.SphereCast(ray, sphereRadius, out hit, sphereLenght, detectLayers))
        {
            pressE.enabled = false;
            pressE = null;
            CanvasNpc.enabled = false;
            canvasEnable = false;
            CanvasNpc = null;
        }
        

    }
}
