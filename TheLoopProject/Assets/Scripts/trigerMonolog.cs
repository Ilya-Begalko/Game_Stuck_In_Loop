using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class trigerMonolog : MonoBehaviour
{
    public GameObject gm;
    Monolog mon;
    public string[] text1;

    private void Start()
    {
        mon = gm.GetComponent<Monolog>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            mon.Mono(text1);
            Destroy(gameObject);
        }
    }
}
