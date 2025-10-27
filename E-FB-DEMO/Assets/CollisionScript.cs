using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionScript : MonoBehaviour
{

    public LogicSCript Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicSCript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Logic.addScore();
    }
}
