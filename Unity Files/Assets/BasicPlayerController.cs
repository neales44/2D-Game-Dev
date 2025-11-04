using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
public class BasicPlayerController : MonoBehaviour
{

    // general movement
    private Rigidbody2D rb;
    public GameObject cameraTarget;
    public float movementIntensity;
    public float jumpVelocity;

    // ground collision
    public int jumpTotal;
    public int jumpCount;
    public float groundCheckDist;
    public float rayWidth = 0.5f;
    public LayerMask groundLayer;
    public bool onGround = false;
    public bool alreadyJumped = false;

    // pickup values (items, etc)
    public bool can_win = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = jumpTotal;
    }

    void Update()
    {

        // movement direction vectors
        var UpDirection = new Vector2(0, 10);
        var RightDirection = new Vector2(10, 0);

        // ground collision
        // making some left/right rays to cast based on input distance
        var left_ray = transform.position;
        left_ray.x -= rayWidth;

        var right_ray = transform.position;
        right_ray.x += rayWidth;

        // create each raycast for checking
        RaycastHit2D center_hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDist, groundLayer);
        RaycastHit2D left_hit = Physics2D.Raycast(left_ray, Vector2.down, groundCheckDist, groundLayer);
        RaycastHit2D right_hit = Physics2D.Raycast(right_ray, Vector2.down, groundCheckDist, groundLayer);

        // if any of the rays hit, set onGround to true
        if (center_hit.collider != null || left_hit.collider != null || right_hit.collider != null)
        {
            //Debug.Log(center_hit.collider);
            //Debug.Log(left_hit.collider); 
            //Debug.Log(right_hit.collider);
            onGround = true;
            jumpCount = jumpTotal; // resets jumps every time ground is touched
        }

        // purely for visual debugging, the visual lines represent the raycast checks
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDist, center_hit.collider != null ? Color.green : Color.red);
        Debug.DrawRay(left_ray, Vector2.down * groundCheckDist, left_hit.collider != null ? Color.green : Color.red);
        Debug.DrawRay(right_ray, Vector2.down * groundCheckDist, right_hit.collider != null ? Color.green : Color.red);

        // Move Up
        if (Input.GetKey(KeyCode.Space))
        {
            // alreadyJumped prevents holding the space bar causing all jumps to be used rapidly
            if (jumpCount > 0 && alreadyJumped == false)
            {
                var curr_vel = rb.linearVelocity;
                if (curr_vel.y < 0)
                {
                    curr_vel.y = 0;
                }
                // removed Time.deltaTime, as this is a set velocity jump, not consistent movement
                rb.linearVelocity = curr_vel + (UpDirection * jumpVelocity);
                alreadyJumped = true;
                jumpCount--;
            }
        }

        // Checking for letting go of Space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            alreadyJumped = false;
        }

        // Move Down
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-UpDirection * movementIntensity * Time.deltaTime);
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(RightDirection * movementIntensity * Time.deltaTime);
        }

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-RightDirection * movementIntensity * Time.deltaTime);
        }
    }

    // determines if the player can open the exit
    public void pickupkey()
    {
        if (!can_win)
        {
            can_win = true;
        }
    }
}