using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stretchSpeed = 1f; // Adjust the stretching speed
    public float shrinkSpeed = 1f;  // Adjust the shrinking speed

    private bool isStretchingHorizontally = false;
    private bool isShrinkingHorizontally = false;
    private bool isStretchingVertically = false;
    private bool isShrinkingVertically = false;

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Normalize the movement vector to ensure constant speed
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Move the GameObject
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Check for stretching input
        isStretchingHorizontally = Input.GetKey("k");
        isShrinkingHorizontally = Input.GetKey("l");
        isStretchingVertically = Input.GetKey("u");
        isShrinkingVertically = Input.GetKey("j");

        // Stretch the sprite horizontally
        if (isStretchingHorizontally)
        {
            transform.localScale = new Vector3(transform.localScale.x + stretchSpeed * Time.deltaTime, transform.localScale.y, 1f);
        }

        // Shrink the sprite horizontally
        if (isShrinkingHorizontally)
        {
            transform.localScale = new Vector3(transform.localScale.x - shrinkSpeed * Time.deltaTime, transform.localScale.y, 1f);
        }

        // Stretch the sprite vertically
        if (isStretchingVertically)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + stretchSpeed * Time.deltaTime, 1f);
        }

        // Shrink the sprite vertically
        if (isShrinkingVertically)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - shrinkSpeed * Time.deltaTime, 1f);
        }
    }
}
