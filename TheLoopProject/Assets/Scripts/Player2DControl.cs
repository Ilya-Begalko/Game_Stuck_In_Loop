using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2DControl : MonoBehaviour
{
    public float speed = 35;
    public float addForce = 3f;
    public bool lookAtCursor;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode downButton = KeyCode.S;
    public KeyCode addForceButton = KeyCode.W;
    public bool isFacingRight = true;
    private Vector3 direction;
    private float horizontal;
    private Rigidbody2D body;
    private bool jump;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        RaycastHit2D[] raycast = new RaycastHit2D[1];
        GetComponent<BoxCollider2D>().Raycast(Vector2.up, raycast);

        if (raycast[0].collider != null && Mathf.Abs(raycast[0].collider.transform.position.y + raycast[0].collider.offset.y - transform.position.y) > 1.5f && raycast[0].collider.tag == "Ground")
        {
            if (coll.transform.tag == "Ground")
            {
                body.drag = 2;
                jump = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 0;
            jump = false;
        }
    }

    void FixedUpdate()
    {
        body.AddForce(direction * body.mass * speed);

        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
        }
        if (Input.GetKey(addForceButton) && jump)
        {
            body.velocity = new Vector2(0, addForce);
        }

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(new Vector3(0, 180 * horizontal, 0));
    }

    void Update()
    {
        if (Input.GetKey(leftButton)) horizontal = -1;
        else if (Input.GetKey(rightButton)) horizontal = 1; else horizontal = 0;

        direction = new Vector2(horizontal, 0);

        if (horizontal != 0)
        {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false);
        }

        if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
    }
}