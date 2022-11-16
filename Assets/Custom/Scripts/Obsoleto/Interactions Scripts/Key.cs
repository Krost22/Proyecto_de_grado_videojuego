using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    InventorySystem inventorySystem;
    public bool HasKey = false;

    // Update is called once per frame
    void Update()
    {
        //Codigo para saber si el jugador tiene un objeto en especifico
        while (HasKey==true)
        {
            int i =+ 1;
            if (inventorySystem.inventorySlots[i].ItemData.ID == 0) //El ID tiene que coincidir con el ID del objeto en este caso es de la llave (Key)
            {
                HasKey = true;
                Debug.Log("Abres la puerta");
                
            }
            break;
        }

       
    }
}
