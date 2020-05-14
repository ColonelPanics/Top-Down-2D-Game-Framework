using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : CollisionBase
{
    private Canvas messageCanvas;
    
    // Start is called before the first frame update
    public override void StartExtras()
    {
        messageCanvas = this.GetComponentInChildren<Canvas>();
        messageCanvas.enabled = false;
    }
    
    public override void DoThing() {
        messageCanvas.enabled = true;
    }
    
    public override void UndoThing() {
        messageCanvas.enabled = false;
    }

}
