using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleSceneManager : MonoBehaviour
{
    public void OpenNewScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
