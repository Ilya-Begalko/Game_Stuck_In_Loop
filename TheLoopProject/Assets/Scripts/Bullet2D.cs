using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet2D : MonoBehaviour
{

    public string shooterTag;
    public float timeToDestroy;

    public void SetTag(string tag)
    {
        this.shooterTag = tag;
    }

    public void SetTime(float time)
    {
        this.timeToDestroy = time;
    }

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger && coll.tag != shooterTag) // чтобы пуля не реагировала на триггер
        {
            switch (coll.tag)
            {
                case "Enemy 1":
                    {
                        coll.transform.GetComponent<EnemyBehaviour>().isDead = true;
                        break;
                    }

                case "Enemy 2":
                    {
                        break;
                    }
                case "NPC":
                case "Player":
                    {
                        coll.transform.GetComponent<PlayerInterface>().SetDead(true);
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }
}
