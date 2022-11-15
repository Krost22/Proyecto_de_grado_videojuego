using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    public InventorySystem InventorySystem => inventorySystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    //La funcion Awake() nos permite ejecutar una accion en el frame 0 al undir play, a diferencia Start() que empieza en el frame 1
    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
    }
}
