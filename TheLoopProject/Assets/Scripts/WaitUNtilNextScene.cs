using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitUNtilNextScene : MonoBehaviour
{
    public string scene;
    private float currTime = 0;
    public float time;
    public bool canTime = false;

    // Update is called once per frame
    void Update()
    {

        if (currTime > time)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        currTime += Time.deltaTime;

    }
}
