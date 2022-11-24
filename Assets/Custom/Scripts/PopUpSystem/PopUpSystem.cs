using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public TextMeshProUGUI NpcName;
    public TextMeshProUGUI NpcText;
    string NombreNpc = "Fulano de tal";
    string DialogoNpc = "Hola esto es un texto de prueba";

    public GameObject CanvasNpc;
    public Canvas Cn;

    public PlayerMovement playerMovement;

    private void Awake()
    {
        NpcName.text = NombreNpc;
        NpcText.text = DialogoNpc;
        Cn = CanvasNpc.GetComponent<Canvas>();
        
    }

    private void Update()
    {
       // playerMovement.NPCRayCast();
    }

    //public void EnabledCn()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && Cn.enabled == false)
    //    {
    //        Cn.enabled = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.E) && Cn.enabled == true)
    //    {
    //        Cn.enabled = false;
    //    }
    //}

}
