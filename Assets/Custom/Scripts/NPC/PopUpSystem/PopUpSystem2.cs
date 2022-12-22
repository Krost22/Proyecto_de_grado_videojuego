using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem2 : MonoBehaviour
{
    public Canvas CanvasNpc;
    public Canvas pressE;
    bool canvasEnable;
    public BoxCollider playerCollider;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Npc")
        {
            CanvasNpc = other.transform.Find("CanvasNpc").GetComponent<Canvas>();
            pressE = other.transform.Find("Press E").GetComponent<Canvas>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Npc")
        {
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
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Npc")
        {
            pressE.enabled = false;
            pressE = null;
            CanvasNpc.enabled = false;
            canvasEnable = false;
            CanvasNpc = null;
        }
    }
}
