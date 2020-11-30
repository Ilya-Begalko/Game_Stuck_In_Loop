using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Monolog : MonoBehaviour
{
    public Canvas canvas;
    public string[] text;
    private string[] first;
    Canvas clone;
    // Start is called before the first frame update
    void Start()
    {
        /*clone = Instantiate(canvas, gameObject.transform.position, Quaternion.identity);
        clone.GetComponentInChildren<Text>().text = text[0];*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && i < text.Length)
        {
            clone.GetComponentInChildren<Text>().text = text[i];
            i++;
        }
        else if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && i == text.Length)
        {
            clone.enabled = false;
        }*/
    }

    public void Mono(string[] first)
    {
        this.first = first;
        clone = Instantiate(canvas, gameObject.transform.position, Quaternion.identity);
        clone.transform.SetParent(transform);
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        ControllerOff controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerOff>();
        if ( controller != null)
        {
            StartCoroutine(controller.PlayCrt(first.Length * 3));
        }
        int i = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (i < first.Length)
        {
            clone.enabled = true;
            clone.GetComponentInChildren<Text>().text = first[i];
            yield return new WaitForSeconds(3);
            clone.enabled = false;
            i++;
        }
        clone.enabled = false;
    }

}