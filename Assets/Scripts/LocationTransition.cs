using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTransition : MonoBehaviour
{
    public BoxCollider2D entrance;
    public BoxCollider2D gotoLocation;

    private GameObject player;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("Action"))
            {
                player = GameObject.FindWithTag("Player");
                player.transform.position = gotoLocation.bounds.center;
            }
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
