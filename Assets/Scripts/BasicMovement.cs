using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Animator am;
    private Rigidbody2D rb;

    private Vector3 movement;
    private Camera mainCam;
    
    private float lastmovex;
    private float lastmovey;
    
    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();

        mainCam = this.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get & set movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, vertical, 0.0f);
        
        // Set idle face direction
        if (movement.x != 0 || movement.y != 0 ) {
            // Horizontal last direction
            if (movement.x < 0) {
                lastmovex = -1f;
            }
            else if (movement.x > 0) {
                lastmovex = 1f;
            }
            else {
                lastmovex = 0f;
            }
            
            // Vertical last direction
            if (movement.y < 0) {
                lastmovey = -1f;
            }
            else if (movement.y > 0) {
                lastmovey = 1f;
            }
            else {
                lastmovey =  0f;
            }
        }

        // Constrain float values for use with animation
        float hf = horizontal > 0.01f ? horizontal : horizontal < -0.01f ? 1 : 0;
        float vf = vertical > 0.01f ? vertical : vertical < -0.01f ? 1 : 0;

        if (horizontal < -0.01f || lastmovex < -0.01f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        // Set various animation values
        am.SetFloat("horizontal", hf);
        am.SetFloat("vertical", vertical);
        am.SetFloat("speed", vf);
        am.SetFloat("magnitude", movement.magnitude);
        am.SetFloat("LastMoveX", lastmovex);
        am.SetFloat("LastMoveY", lastmovey);
    }

    // End of each update loop, proper place to move
    void FixedUpdate()
    {
        // Move character
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    // Set camera bounds based on which "map" collider is being hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Map"))
        {
            Debug.Log("Setting mapBounds to " + collision);
            var cameraController = mainCam.GetComponent<CameraController>();
            var newBounds = collision.GetComponent<BoxCollider2D>();
            cameraController.mapBounds = newBounds;
            cameraController.UpdateMapBounds();
        }
    }
}
