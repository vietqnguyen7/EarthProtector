using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadClick : MonoBehaviour
{

    
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 0;
    }
}
