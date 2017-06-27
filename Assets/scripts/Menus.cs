using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

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
    
}

