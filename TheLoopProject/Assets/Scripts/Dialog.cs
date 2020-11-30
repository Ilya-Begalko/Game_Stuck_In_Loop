using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Canvas canvas;
    public string[] text;
    private int i = 1;

    private string[] first;
    private string[] second;

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

    public void Diall(string[] first)
    {
        this.first = first;
        clone = Instantiate(canvas, gameObject.transform.position, Quaternion.identity);
        clone.transform.SetParent(transform);
        StartCoroutine(WaitCoroutine());
        //Destroy(clone);
        //clone.enabled = false;
    }

    IEnumerator WaitCoroutine()
    {
        Player2DControlHome pl;
        gameObject.TryGetComponent<Player2DControlHome>(out pl);
        if (pl != null)
        {
            pl.enabled = false;
            GetComponent<Animator>().SetBool("Running", false);
        }
        int i = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (i < first.Length)
        {
            clone.enabled = true;
            clone.GetComponentInChildren<Text>().text = first[i];
            yield return new WaitForSeconds(3);
            clone.enabled = false;
            yield return new WaitForSeconds(3);
            i++;
        }
        clone.enabled = false;
        if (pl != null)
        {
            pl.enabled = true;
            GetComponent<Animator>().SetBool("Running", false);
        }
    }

    public void Diall2(string[] first)
    {
        this.first = first;
        StartCoroutine(WaitCoroutine2());
        //Destroy(clone);
        //clone.enabled = false;
    }

    IEnumerator WaitCoroutine2()
    {
        Player2DControlHome pl;
        gameObject.TryGetComponent<Player2DControlHome>(out pl);
        if (pl != null) pl.enabled = false;
        int i = 0;
        yield return new WaitForSeconds(3);
        clone = Instantiate(canvas, gameObject.transform.position, Quaternion.identity);
        clone.transform.SetParent(transform);
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (i < first.Length)
        {
            clone.enabled = true;
            clone.GetComponentInChildren<Text>().text = first[i];
            yield return new WaitForSeconds(3);
            clone.enabled = false;
            yield return new WaitForSeconds(3);
            i++;
        }
        clone.enabled = false;
        if (pl != null) pl.enabled = true;
    }

}
