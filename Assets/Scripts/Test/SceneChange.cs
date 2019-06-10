using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    
    public void SceneStart()
    {
        SceneManager.LoadScene("Main");

    }

    public void SceneBack()
    {
        SceneManager.LoadScene("Start");

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
    