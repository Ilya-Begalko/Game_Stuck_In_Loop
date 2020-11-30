using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public bool isMainHero = false;
    public Transform firePoint;
    public float speed = 3f;
    public GameObject bullet;
    public float firerate = 1f;

    private float curTimeout = 100f;

    private void Update()
    {
        if (isMainHero)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
            else
            {
                curTimeout += Time.deltaTime;
            }
        }
    }

    public void Fire()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > firerate)
        {
            curTimeout = 0;
            bullet.GetComponent<Bullet2D>().SetTag(gameObject.tag);
            bullet.GetComponent<Bullet2D>().SetTime(isMainHero ? 0.3f : 1f);
            Rigidbody2D clone = Instantiate(bullet.GetComponent<Rigidbody2D>(), firePoint.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = firePoint.right * speed;
            clone.transform.right = firePoint.right;
        }
    }
}
