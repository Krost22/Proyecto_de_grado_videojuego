using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject RutaDestino;

    Animator animator;
    const string STATE_QUIETO = "Quieto";
    const string STATE_CORRER = "Correr";

//para saber cuando hay doble click del jugador
    float lastClickTime;
    private object setbool;
    const float DOUBLE_CLICK_TIME = 0.2F;

    // Start is called before the first frame update
    void Start()
    {
        //El agente vendria siendo el personaje que es afectado por el asset NAVMESH
        agent = GetComponent<NavMeshAgent>();

        //Aqui importamos el parametro animator para controlar las animaciones
        animator = GetComponent<Animator>();

        RutaDestino = GameObject.Find("RutaDestino");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool(STATE_QUIETO) == true)
        {
            animator.SetBool(STATE_CORRER, false);
        }

        Quieto();

        
        Correr();

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //Distancia maxima del rayo en este caso es infinita
            {
                agent.SetDestination(hit.point); //mueve al agente a donde golpeo el ray
                RutaDestino.transform.position = hit.point; //mueve el puntero a la misma ubicacion que el ray
            }
        }
        Debug.DrawRay(transform.position, transform.forward);
    }

    void Quieto()
    {
         //Si el agente tiene la velocidad de todos sus ejes (XYZ) menor o igual a 0. El agente está STATE_QUIETO para el ANIMATOR
        if (agent.velocity.magnitude <= 0)
        {
            animator.SetBool(STATE_QUIETO, true);
        }
        else if(agent.velocity.magnitude > 0)
        {
            animator.SetBool(STATE_QUIETO, false);
        }
    }
        
    //void Correr()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        agent.speed = 5;
    //        animator.SetBool(STATE_CORRER, true);
    //    }
    //    else
    //    {
    //        agent.speed = 2;
    //        animator.SetBool(STATE_CORRER, false);
    //    }
    //}

    void Correr()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
            {
                //DOBLE CLICK

                agent.speed = 5;
                animator.SetBool(STATE_CORRER, true);
            }
            else 
            {
                //NORMAL CLICK
                agent.speed = 2;
                animator.SetBool(STATE_CORRER, false);

            }

            lastClickTime = Time.time;
        }
    }
}
