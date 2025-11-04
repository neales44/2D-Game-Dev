using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{

    public SpriteRenderer spriteText;

    private void Start()
    {
        spriteText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        spriteText.enabled = true;
        Debug.Log("Player collided with " + collision.name);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        spriteText.enabled = false;
        Debug.Log("Player left the collision with " + collision.name);
    }
}