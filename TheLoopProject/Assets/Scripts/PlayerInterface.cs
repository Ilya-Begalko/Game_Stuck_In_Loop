using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerInterface : MonoBehaviour
{
    private bool isDead = false;

    public void SetDead(bool death)
    {
        isDead = death;
    }

    private void Update()
    {
        if (isDead)
        {
            if (gameObject.tag == "Player") SceneManager.LoadScene("RepeatSceneNumber2");
            Destroy(gameObject);
        }
    }
}
