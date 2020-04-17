using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Config
    [SerializeField] float moveSpeed = 1f;

    // Cached component references
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        Vector2 playerVelocity;
        if (IsFacingRight())
        {
            playerVelocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        } else
        {
            playerVelocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
        }
        myRigidBody.velocity = playerVelocity;
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), transform.localScale.y);
    }
}
