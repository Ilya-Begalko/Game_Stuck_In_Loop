using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class ControllerOff : MonoBehaviour
{
    public IEnumerator PlayCrt(float time)
    {
        GameObject player = GameObject.FindWithTag("Player");
        Player2DControlHome player2DControlHome = player.gameObject.GetComponent<Player2DControlHome>();
        player2DControlHome.enabled = false;
        player.gameObject.GetComponent<Animator>().SetBool("Running", false);
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(time);
            i++;
        }
        GameObject.FindWithTag("Player").gameObject.GetComponent<Player2DControlHome>().enabled = true;
    }
}
