using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on movement tutorial from https://www.youtube.com/watch?v=K1xZ-rycYY8&t
public class PlayerMovement : MonoBehaviour

{
    private float horizontal;
    private float speed = 3f;
    private bool faceSide = true;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the keyboard input
        horizontal = Input.GetAxisRaw("Horizontal");

    }

    // takes care of mthe player's movement
    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip() {
        if (faceSide && horizontal < 0f || !faceSide && horizontal > 0f) {
            faceSide = !faceSide;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
