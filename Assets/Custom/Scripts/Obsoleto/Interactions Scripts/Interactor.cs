using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float     _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
                                                  _interactableMask);

        if (_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<InteractorInterface>();

            if (interactable != null && Input.GetKeyDown("e"))
            {
                interactable.Interact(this);
            }
        }
        else if(Input.GetKeyDown("e"))
        {
            Debug.LogWarning("No hay nada cerca para interactuar");
        }
    }

    private void OnDrawGizmos() //colorearlo de color rojo la zona que detecta  si hay interaccion
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
