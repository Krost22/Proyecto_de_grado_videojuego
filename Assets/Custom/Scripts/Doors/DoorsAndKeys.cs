using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XEntity;

public class DoorsAndKeys : MonoBehaviour
{
    //public ItemManager im;
    public ItemContainer ic;

    public string itemN;
    private void Start()
    {
    }
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //si lo que esta atravesando el collider es el jugador, hacer...
        {
            for (int i = 0; i < 1; i++)
            {

                if (ic.slots[i].slotItem.itemName == itemN && ic.slots[i].slotItem.itemName != null)
                {
                    Debug.Log("Abriste la puerta");
                    GameObject.Destroy(this.gameObject);

                }
                else if (ic.slots[i].slotItem.itemName != itemN && ic.slots[i].slotItem.itemName == null)
                {
                    Debug.Log("NO TIENES LA LLAVE");

                }

            }
        }

    }

}
