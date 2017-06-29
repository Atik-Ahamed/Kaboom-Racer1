using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutPanel;
    public Slider slider;
    public Toggle tgl;
    public GameObject gravityPanel;
    public CanvasGroup maincnvsGroup;
    public Text highScore;
    public GameObject loadingPanel;
    public GameObject pr;

    private void Awake()
    {
        aboutPanel.SetActive(false);
        pr.SetActive(true);
        loadingPanel.SetActive(false);
        gravityPanel.SetActive(false);
        tgl.transition = Selectable.Transition.Animation;
        PlayerPrefs.SetInt("gravity", 0);
        highScore.text = "BEST : "+PlayerPrefs.GetInt("HighScore").ToString();
     
    }

    public void loadGame()
    {
        StartCoroutine(LoadAsynchronously(1));
    }

    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = operation.progress;
            slider.value = (progress + 0.1f);
            yield return null;
        }
    }

    public void loadSettings()
    {
        gravityPanel.SetActive(true);
        maincnvsGroup.alpha = 0.01f;
        maincnvsGroup.interactable = false;


    }
    public void quitGravityOption()
    {
        gravityPanel.SetActive(false);
        maincnvsGroup.interactable = true;
        maincnvsGroup.alpha = 1.0f;
    }
    public void ToggleGravity()
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("gravity", 1);
        }
        else
        {
            PlayerPrefs.SetInt("gravity", 0);
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void about()
    {
        aboutPanel.SetActive(true);

    }
    public void quitAbout()
    {
        aboutPanel.SetActive(false);
    }
  
}