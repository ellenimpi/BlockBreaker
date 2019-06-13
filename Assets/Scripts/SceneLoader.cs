using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex!= (SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
        else
        {
            SceneManager.LoadScene(0);
            FindObjectOfType<GameStatus>().ResetGame();
            Debug.Log("Reset");
        }
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
