using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{

    public Button[] buttonLevel;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttonLevel.Length; i++)
        {
            if(i + 2 > PlayerPrefs.GetInt("FaseCompletada"))
            {
                buttonLevel[i].interactable = false;
            }
        }    
    }
}
