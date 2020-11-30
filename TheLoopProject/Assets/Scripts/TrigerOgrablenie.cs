using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Playables;

public class TrigerOgrablenie : MonoBehaviour
{
    public GameObject gm;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public AudioSource knockKnock;
    public int howTimePlaySnd = 3;
    public float timeToActivateGangsters = 18f;
    public GameObject[] triggersToActivate;
    public GameObject chairTrigger;

    private bool isStart;
    private float time = 0f;

    private void Start()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            time += Time.deltaTime;
        }
        if (time > timeToActivateGangsters)
        {
            enemy1.active = true;
            enemy2.active = true;
            enemy3.active = true;
            foreach (GameObject trigger in triggersToActivate)
            {
                trigger.SetActive(true);
            }
            Destroy(chairTrigger);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            isStart = true;
            chairTrigger.SetActive(true);
            StartCoroutine(PlayCrtn());
            gm.GetComponent<PlayableDirector>().enabled = true;
        }
    }

    IEnumerator PlayCrtn()
    {
        int cnt = 0;
        while (cnt < howTimePlaySnd)
        {
            knockKnock.pitch = Random.Range(0.8f, 1.5f);
            knockKnock.PlayOneShot(knockKnock.clip);
            cnt++;
            yield return new WaitForSeconds(knockKnock.clip.length + Random.Range(1.0f, 3.0f));
        }
    }


}
