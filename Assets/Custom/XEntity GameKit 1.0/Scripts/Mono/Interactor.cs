using UnityEngine;

namespace XEntity
{
    //This class is attached to the player.
    //This holds the different types of interaction events and interaction trigger methods.
    public class Interactor : MonoBehaviour
    {
        //The minimum distance to an object in order to interact.
        [SerializeField] private float interactionRange;

        //Reference to the main game viewing camera.
        [SerializeField] private Camera mainCamera;

        //Reference to the item container thats dedicated to this interactor.
        [SerializeField] private ItemContainer inventory;

        //Reference to the current interactable target.
        //This is null if there are no valid target interactable objects. 
        private Interactable interactionTarget;

        //Activating the range indicator, draws a wire sphere to indicate interaction range in the editor.
        [Header("Settings")]
        public bool drawRangeIndicator;

        //This is the color target interactable objects are highlighted.
        //The interactable objects must have a mesh renderer with a valid material in order to be highlighted.
        public Color interactableHighlight = Color.white;

        //This is the position at which dropped items will be instantiated (in front of this interactor).
        public Vector3 ItemDropPosition { get { return transform.position + transform.forward; } }

        //Called every frame after the game is started.
        private void Update()
        {
            HandleInteractions();
        }

        //This method draws gizmos in the editor.
        private void OnDrawGizmos() 
        {
            if (drawRangeIndicator) 
            {
                Gizmos.DrawWireSphere(transform.position, interactionRange);
            }
        }

        //This method handles the interactable object detection, interaction trigger and the interaction event callbacks.
        private void HandleInteractions()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (interactionTarget) Utils.UnhighlightObject(interactionTarget.gameObject);

            if (Physics.Raycast(ray, out hit) && InRange(hit.transform.position))
            {
                Interactable target = hit.transform.GetComponent<Interactable>();
                if (target != null)
                {
                    interactionTarget = target;
                    Utils.HighlightObject(interactionTarget.gameObject, interactableHighlight);
                }
                else interactionTarget = null;
            }
            else
            {
                interactionTarget = null;
            }

            if (Input.GetMouseButtonDown(1)) InitInteraction(); //Interactuar con los objetos con click derecho
        }

        //This returns true if the target position is within the interaction range.
        private bool InRange(Vector3 targetPosition)
        {
            return Vector3.Distance(targetPosition, transform.position) <= interactionRange;
        }

        //This method initilizes an interaction with this interactor if a valid interactabale target exists.
        private void InitInteraction() 
        {
            if (interactionTarget == null) return;
            interactionTarget.OnInteract(this);
        }

        //This method adds items to the inventory of this interactor and if applicable destroys the physical instance of the item.
        public void AddToInventory(Item item, GameObject instance)
        {
            if (inventory.AddItem(item)) 
                if(instance) StartCoroutine(Utils.TweenScaleOut(instance, 50, true));
        }
    }
}
