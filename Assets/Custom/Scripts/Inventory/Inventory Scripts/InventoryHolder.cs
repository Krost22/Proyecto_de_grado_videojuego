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

    //public void Update()
    //{
    //    //Codigo para saber si el jugador tiene un objeto en especifico
    //    for (int i = 0; i < 1; i++)
    //    {
    //        if (inventorySystem.inventorySlots[i].ItemData.ID==0) //El ID tiene que coincidir con el ID del objeto en este caso es de la llave (Key)
    //        {
    //            Debug.Log("Tienes un rabano :D");
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }
        
                
    //}
}
