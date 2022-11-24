using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(loadNextLevel());
    }

    IEnumerator loadNextLevel()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        var currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene + 1);

    }
}

