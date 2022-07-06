using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void StartGame ()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("Bow");
    }

    public void EndGame ()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }  
}
