
using UnityEngine;

public class bicycleSelector : MonoBehaviour {
    private int index;
    private GameObject[] characterList;
    private void Start()
    {
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
        PlayerPrefs.SetInt("bicycleIndex", index);
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
        PlayerPrefs.SetInt("bicycleIndex", index);
    }
}
