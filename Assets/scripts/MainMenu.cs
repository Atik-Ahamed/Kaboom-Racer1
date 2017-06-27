using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public Toggle tgl;
    public GameObject gravityPanel;
    public CanvasGroup maincnvsGroup;
    public Text highScore;

    private void Start()
    {
        gravityPanel.SetActive(false);
        tgl.transition = Selectable.Transition.Animation;
        PlayerPrefs.SetInt("gravity", 0);
        highScore.text = "BEST : "+PlayerPrefs.GetInt("HighScore").ToString();
     
    }

    public void loadGame()
    {

        SceneManager.LoadScene(1);
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

  
}