using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;
using System.Linq;
using UnityEditor.Experimental.TerrainAPI;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour
{
    public float activeDistance = 10;
    public Transform leftPoint;
    public Transform rightPoint;
    public float timeWait = 3;
    public bool isRight;
    public float speed = 1.5f;
    public bool isDead = false;

    private Transform target;
    private bool isWalk = true, isTriggered = false;
    private float curTimeout;
    private Rigidbody2D body;
    private int wayCount = 0;
    private Animator animator;
    private float colliderHeightWhenDie = 0.05f;
    private float colliderWidthWhenDie = 0.34f;



    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        animator = gameObject.GetComponent<Animator>();
        if (!isRight) transform.eulerAngles = new Vector3(0, -180, 0);
    }

    private void Update()
    {
        if (isDead) return;
        isRight = gameObject.transform.forward.x == 0;
        GameObject player = GameObject.FindWithTag("Player");
        GameObject npc = GameObject.FindWithTag("NPC");
        if (player == null && npc == null)
        {
            isWalk = true;
            isTriggered = false;
            return;
        }

        target = player.transform;
        Transform targetToNpc = null;
        if (npc != null)
        {
            targetToNpc = npc.transform;
        }
        float disToPlayer = 100000;
        disToPlayer = Math.Abs(transform.position.x - target.position.x);
        float disToNpc = 100000;
        if (targetToNpc != null)
        {
            disToNpc = Math.Abs(transform.position.x - targetToNpc.position.x);
        }

        float dis = Math.Min(disToNpc, disToPlayer);

        Debug.Log(disToNpc);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right);
        bool isMainHeroAhead = false;
        if (hits != null)
        {
            isMainHeroAhead = hits.Any(hit => hit.collider.tag == "Player");
        }
        if (isMainHeroAhead)
        {
            if (dis < activeDistance)
            {
                isTriggered = true;
                isWalk = false;
            }
            else
            {
                isTriggered = false;
                isWalk = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (isDead)
        {
            Dead();
        }
        else if (isTriggered)
        {
            animator.SetBool("isShooting", true);
            Triggered();
        }
        else if (isWalk)
        {
            animator.SetBool("isShooting", false);
            Walk();
        }
    }

    private void Dead()
    {
        isWalk = false;
        isTriggered = false;
        animator.SetBool("isDead", true);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(colliderWidthWhenDie, colliderHeightWhenDie);
    }

    private void Triggered()
    {
        transform.eulerAngles = new Vector3(0, 180 * ((gameObject.transform.position.x - target.position.x) < 0 ? 0 : -1), 0);
        GetComponent<FireScript>().Fire();
    }

    void Walk()
    {
        float dist;
        if (isRight)
        {
            dist = Math.Abs(transform.position.x - rightPoint.position.x);
        }
        else
        {
            dist = Math.Abs(transform.position.x - leftPoint.position.x);
        }

        if (dist < 0.1f)
        {
            if (curTimeout <= 0)
            {
                curTimeout = timeWait;
                Rotate();
            }
            else
            {
                animator.SetBool("isRunning", false);
                curTimeout -= Time.deltaTime;
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
    }

    private void Rotate()
    {
        if (isRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            isRight = false;
        }
        else if (isRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            transform.eulerAngles = new Vector3(0, 180 * ((gameObject.transform.position.x - target.position.x) < 0 ? 0 : -1), 0);
        }
        else if (collision.transform.tag == "Enemy 1")
        {
            Rotate();
        }
    }
}
