using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera yourCam;
    public GameObject player;
    Vector3 target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = yourCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(transform.position, hit.point);
                target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                rb.MovePosition(target);
            }
        }
    }
}

