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
        SpawnBolhas.instance.InMenu = false;
    }

    public void ExitPlayButton()
    {
        PlayPanel.SetActive(false);
        SpawnBolhas.instance.InMenu = true;
    }

    public void ActiveSettings()
    {
        SettingsPanel.SetActive(true);
        SpawnBolhas.instance.InMenu = false;
    }

    public void ExitSettings()
    {
        SettingsPanel.SetActive(false);
        SpawnBolhas.instance.InMenu = true;
    }

    public void ActiveCredits()
    {
        CreditsPanel.SetActive(true);
        SpawnBolhas.instance.InMenu = false;
    }

    public void ExitCredits()
    {
        CreditsPanel.SetActive(false);
        SpawnBolhas.instance.InMenu = true;
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

}
