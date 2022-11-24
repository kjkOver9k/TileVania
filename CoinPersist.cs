using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinPersist : MonoBehaviour
{
    int currentscene;

    private void Awake()
    {
        int length = FindObjectsOfType<CoinPersist>().Length;
        if(length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentscene = SceneManager.GetActiveScene().buildIndex;
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentscenecheck = SceneManager.GetActiveScene().buildIndex;
        if(currentscenecheck!=currentscene)
        {
            Destroy(gameObject);
        }
        
    }
}
