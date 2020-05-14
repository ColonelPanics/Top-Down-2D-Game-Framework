using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTransition : CollisionBase
{
    public BoxCollider2D entrance;
    public BoxCollider2D gotoLocation;

    private GameObject player;

    public override void DoThing() {
        player = GameObject.FindWithTag("Player");
        player.transform.position = gotoLocation.bounds.center;
    }
    
}
