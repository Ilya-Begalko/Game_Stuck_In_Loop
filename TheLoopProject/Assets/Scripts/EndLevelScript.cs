using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(12);
        if (Input.GetKey(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            goToNextLevel();
        }
    }

    private void goToNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
