using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class TakeTheObj : MonoBehaviour
{
    public GameObject player;
    private bool hold = false;
    private float putOnGround = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (Input.GetKey(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            if (!hold)
            {
                putOnGround = collision.transform.position.y - gameObject.transform.position.y;
                hold = true;
            }
        }
        if (collision.gameObject.tag == "Finish")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - putOnGround, transform.position.z);
            Destroy(this);
        }
    }

    private void LateUpdate()
    {
        if (hold)
        {
            gameObject.transform.position = player.transform.position;
        }
    }

}
