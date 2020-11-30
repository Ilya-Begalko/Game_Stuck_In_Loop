using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class trigerEvent : MonoBehaviour
{
    public GameObject gm;
    Dialog dil;
    public GameObject gm2;
    Dialog dil2;
    public string[] text1;
    public string[] text2;

    private void Start()
    {
        dil = gm.GetComponent<Dialog>();
        dil2 = gm2.GetComponent<Dialog>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dil.Diall(text1);
            dil2.Diall2(text2);
            if (gameObject.GetComponent<TrigerOgrablenie>() == null)
            {
                Destroy(gameObject);
            } else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
