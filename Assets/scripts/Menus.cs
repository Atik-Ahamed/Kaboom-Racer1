using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public GameObject tlePanel;
	public static void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonRestart()
    {
        Restart();
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        AudioListener.volume = 1.0f;
        Time.timeScale = 1;
        tlePanel.SetActive(false);

    }
}

