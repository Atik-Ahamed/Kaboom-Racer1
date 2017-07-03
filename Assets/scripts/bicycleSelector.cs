
using UnityEngine;

using UnityEngine.UI;
public class bicycleSelector : MonoBehaviour {
    public GameObject lck;
    private int index;
    private GameObject[] characterList;
    private bool isPossible = false;
    private void Start()
    {
        int coin = PlayerPrefs.GetInt("coin");
        isPossible = coin >=100 ? true : false;
        lck.SetActive(false);
        index = PlayerPrefs.GetInt("bicycleIndex");
        characterList = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
        if (!isPossible&&index > 1 && index < transform.childCount)
        {
            lck.SetActive(true);

        }
    }
    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
        if (isPossible||index<=1)
        {
            lck.SetActive(false);
            PlayerPrefs.SetInt("bicycleIndex", index);
        }
        else 
        {
            lck.SetActive(true);
        }
    }
    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index =0;
        }
        characterList[index].SetActive(true);
        if (isPossible || index <= 1)
        {
            lck.SetActive(false);
            PlayerPrefs.SetInt("bicycleIndex", index);
        }
        else
        {
            lck.SetActive(true);
        }
    }
}
