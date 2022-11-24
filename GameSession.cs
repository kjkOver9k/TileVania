using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{
    
    [SerializeField] int lives = 2;
    [SerializeField] int score = 0;
    private void Awake()
    {
        int noofthisobject = FindObjectsOfType<GameSession>().Length;
        if (noofthisobject > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void Update()
    {
        var currentscene = SceneManager.GetActiveScene().buildIndex;
        if (currentscene == 0)
        {
            lives = 2;
            score = 0;
        }
    }

    public void whenCoinIsPicked(int coinscore)
    {
        score += coinscore;
        FindObjectOfType<UIcanvas>().AddScore(score);
    }

    public void ifPlayerDies()
    {
        lives--;
        if(lives==0)
        {
            SceneManager.LoadScene(0);

        }
        else
        {
            var currentscene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentscene);
        }
    }
}
