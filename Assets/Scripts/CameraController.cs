using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public BoxCollider2D mapBounds;

    // Vars to prevent camera going outside of map bounds
    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private Camera mainCam;

    private float camVertExtent;
    private float camHorzExtent;

    // Start is called before the first frame update
    void Start()
    {
        // Set box colliders
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        // Camera info
        mainCam = this.GetComponent<Camera>();
        camVertExtent = mainCam.orthographicSize;
        camHorzExtent = mainCam.aspect * camVertExtent;
    }

    // Update is called once per frame
    void Update()
    {
        camX = Mathf.Clamp(focus.position.x, xMin + camHorzExtent, xMax - camHorzExtent);
        camY = Mathf.Clamp(focus.position.y, yMin + camVertExtent, yMax - camVertExtent);

        this.transform.position = new Vector3(camX, camY, -10);
    }
}
