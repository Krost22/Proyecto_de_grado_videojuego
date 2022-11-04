using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;

    //Creamos una esfera collider que detectará si el jugadór tocó el objeto
    private SphereCollider myCollider;

    private void Awake() //Precarga el siguiente codigo en el frame 0 ( antes de que comience el juego)
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    //cuando esta funcion detecta que algo entró al collider ejecuta la accion
    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();

        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData,1))
        {
            Destroy(this.gameObject);
        }
    }
}
