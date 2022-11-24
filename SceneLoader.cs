using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        var currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene + 1);
    }
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}
