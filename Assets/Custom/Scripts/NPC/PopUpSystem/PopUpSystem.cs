using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{    

    bool m_HitDetect;
    RaycastHit m_Hit;
    
    public Vector3 boxHeight = default;
    public Vector3 maxScale = default;
    Collider m_Collider;
    public float m_MaxDistance;


    public Canvas CanvasNpc;
    public Canvas pressE;
    bool canvasEnable;
    

    private void Awake()
    {        
                               
    }
    private void Start()
    {
        m_Collider = GetComponent<Collider>();
        
    }

    private void Update()
    {
        RayBox();
    }

    private void RayBox()
    {
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect && m_Hit.transform.tag == "Npc")
        {
            Debug.Log("Hit : " + m_Hit.collider.name);

            CanvasNpc = m_Hit.transform.Find("CanvasNpc").GetComponent<Canvas>();
            pressE = m_Hit.transform.Find("Press E").GetComponent<Canvas>();
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
        else if (!m_HitDetect)
        {
            pressE.enabled = false;
            pressE = null;
            CanvasNpc.enabled = false;
            canvasEnable = false;
            CanvasNpc = null; // Para quitar el error por que es null borra esto y ponle un canvas en la interfaz grafica.
        }
    }

    void OnDrawGizmos()
    {       

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            Gizmos.color = Color.green;
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            Gizmos.color = Color.red;
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
