using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Canvas messageCanvas;
    private bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        messageCanvas = this.GetComponentInChildren<Canvas>();
        messageCanvas.enabled = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("Action"))
            {
                messageCanvas.enabled = true;
            }
        } else {
            messageCanvas.enabled = false;
        }
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
        }
    }
}
