using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a1;


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitCoroutine()
    { 
        yield return new WaitForSeconds(5);
        Destroy(a1);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(a1);
        StartCoroutine(WaitCoroutine());
    }
}
