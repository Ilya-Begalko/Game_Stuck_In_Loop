using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNextTrigger : MonoBehaviour
{
    public GameObject triggerToActivate = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerToActivate != null) triggerToActivate.SetActive(true);
        Destroy(gameObject);
    }
}
