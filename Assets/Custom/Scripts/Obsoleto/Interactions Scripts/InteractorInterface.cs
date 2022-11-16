using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractorInterface
{
    public string InteractionPromp { get; }
    public bool Interact(Interactor interactor);
}
