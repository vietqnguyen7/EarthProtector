using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public EnemyShoot ES;

    void Start()
    {
        PauseUI.SetActive(false);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                PauseUI.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                PauseUI.SetActive(true);
            }
        }

    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        PauseUI.SetActive(false);
    }

    public void MainMenu()
    {
        ES.ResetVariables();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
