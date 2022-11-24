using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcanvas : MonoBehaviour
{
    [SerializeField] Text scoretext;
    [SerializeField] Text livestext;

    private void Awake()
    {
        int noofthisobject = FindObjectsOfType<UIcanvas>().Length;
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
        if(currentscene==0)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int updatescore)
    {
        scoretext.text =updatescore.ToString();
    }


}
