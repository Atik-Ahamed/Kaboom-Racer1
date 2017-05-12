using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public static void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene(0);
    }
}

