using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    private bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        StartExtras();
    }

    // Update is called once per frame
    void Update()
    {
        ActionRange();
    }
    
    // Check if inRange and action button pressed
    void ActionRange() {
        if(inRange)
        {
            if (Input.GetButtonDown("Action"))
            {
                DoThing();
            }
        }
    }
    
    // Additional things to do at start
    public virtual void StartExtras() {
        // Blank
    }
        
    // Thing to do when inRange and action pressed
    public virtual void DoThing() {
        Debug.Log("DoThing not overridden!");
    }
    
    // Thing to do when out of range for first time
    public virtual void UndoThing() {
        Debug.Log("UndoThing not overridden (this is optional)");
    }
    
    // Set inRange
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    // Set Out of Range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            UndoThing();
        }
    }
    
}
