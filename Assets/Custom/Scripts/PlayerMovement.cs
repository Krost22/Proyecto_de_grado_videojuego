using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    Rigidbody rigidbody; //con el rigid body podemos saber la velocidad del personaje

    Animator animator;
    const string STATE_QUIETO = "Quieto";

    // Start is called before the first frame update

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        rigidbody = GetComponent<Rigidbody>();

        //Aqui importamos el parametro animator para controlar las animaciones
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude <= 0)
        {
            animator.SetBool(STATE_QUIETO, true);
        }

        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) //Distancia maxima del rayo en este caso es infinita
            {
                agent.SetDestination(hit.point);

                animator.SetBool(STATE_QUIETO, false);

            }
        }
    }
}
