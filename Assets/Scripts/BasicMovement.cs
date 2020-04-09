using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Animator am;


    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0.0f);

        // Move character
        transform.position = transform.position + movement * speed * Time.deltaTime;

        // Constrain float values for use with animation
        float hf = horizontal > 0.01f ? horizontal : horizontal < -0.01f ? 1 : 0;
        float vf = vertical > 0.01f ? vertical : vertical < -0.01f ? 1 : 0;

        if (horizontal < -0.01f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        //am.SetFloat("horizontal", hf);
        am.SetFloat("horizontal", hf);
        am.SetFloat("vertical", vertical);
        am.SetFloat("speed", vf);
        am.SetFloat("magnitude", movement.magnitude);
    }
}
