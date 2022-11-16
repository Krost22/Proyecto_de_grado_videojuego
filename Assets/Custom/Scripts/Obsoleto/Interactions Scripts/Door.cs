using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InteractorInterface
{
    public InventorySystem inventorySystem;

    [SerializeField] private string _prompt;

    
    public string InteractionPrompt => _prompt;

    public string InteractionPromp => throw new System.NotImplementedException();

   
    public bool Interact(Interactor interactor)
    {
        var hasKey = interactor.GetComponent<Key>();

        if (hasKey == null) return false;

        if (hasKey.HasKey)
        {
            Debug.Log("Abriste la puerta");
            return true;
        }

        Debug.Log("No Key Found");
        return false;

        
        

        

        ////Codigo para saber si el jugador tiene un objeto en especifico
        //for (int i = 0; i < 1; i++)
        //{
        //    if (inventorySystem.inventorySlots[i].ItemData.ID == 0) //El ID tiene que coincidir con el ID del objeto en este caso es de la llave (Key)
        //    {
        //        Debug.Log("Abres la puerta");

               

        //    }
        //    else
        //    {
        //        Debug.Log("Te falta la llave");
               
                
        //    }
        //}
        
    }
}
