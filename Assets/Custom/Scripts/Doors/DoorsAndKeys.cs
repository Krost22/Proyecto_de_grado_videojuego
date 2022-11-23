using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XEntity;

public class DoorsAndKeys : MonoBehaviour
{
    //public ItemManager im;
    public ItemContainer ic;
    public string itemName;
    public ItemSlot[] arrayObjeto;
    private void Start()
    {
        arrayObjeto = ic.slots;
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //si lo que esta atravesando el collider es el jugador, hacer...
        {
            foreach (ItemSlot itemSlot in arrayObjeto) //busca la llave en el inventario
            {
                if(itemSlot.slotItem.itemName==itemName) //si tienes un objeto que coincida con el nombre de la llave...
                {

                    Debug.Log("WAOS");                   //Logica para abrir una puerta
                    Destroy(this.gameObject, 2);

                    break;//si lo encontraste deja de buscar.
                }
            }

        }
        
    }

}
