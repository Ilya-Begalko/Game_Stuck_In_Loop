using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    Canvas cav;
    Quaternion qua;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent<Canvas>(out cav);
        //ua = cav.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (cav != null)
        {
            cav.transform.rotation = qua;
        }
        gameObject.TryGetComponent<Canvas>(out cav);
    }
}
