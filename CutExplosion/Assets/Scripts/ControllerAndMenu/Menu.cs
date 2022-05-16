using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public GameObject CreditsPanel;
    public GameObject PlayPanel;

    public void ActivePlayButton()
    {
        PlayPanel.SetActive(true);
    }

    public void ExitPlayButton()
    {
        PlayPanel.SetActive(false);
    }

    public void ActiveSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void ActiveCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsPanel.SetActive(false);
    }

    public void TutorialButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

}
