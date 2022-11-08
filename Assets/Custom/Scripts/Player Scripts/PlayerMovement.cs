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
        Correr();

        Quieto();

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
        else
        {
            animator.SetBool(STATE_QUIETO, false);
        }
    }
        
    void Correr()
    {
        if (Input.GetMouseButton(0))
        {
            agent.speed = 5;
            animator.SetBool(STATE_CORRER, true);
        }
        else
        {
            agent.speed = 2;
            animator.SetBool(STATE_CORRER, false);
        }
    }
}
