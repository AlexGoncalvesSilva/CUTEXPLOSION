 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public GameObject EndLevelPanel;

    public void LevelButton(int i)
    {
        SceneManager.LoadScene(i);
        Time.timeScale = 1;
    }

    public void NextLevelButton(int i)
    {
        EndLevelPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndLevelPanel.SetActive(true);
            Time.timeScale = 0;
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("FaseCompletada"))
            {
                PlayerPrefs.SetInt("FaseCompletada", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }
        }
    }
}