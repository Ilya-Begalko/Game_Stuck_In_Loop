using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGrey : MonoBehaviour
{
    public GameObject cam;
    public GameObject music;

    private void OnDestroy()
    {
        cam.GetComponent<SimpleFilter>().enabled = true;
        music.SetActive(true);
    }
}
