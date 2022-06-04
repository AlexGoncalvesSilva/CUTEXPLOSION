using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int Score;
    public int Life;

    public Text lifeText;
    public Text ScoreText;

    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject CheckPoint;
    public GameObject Player;
    public GameObject Bg;
    public GameObject BgPosition;
    public GameObject Clouds;
    public GameObject CloudPosition;

    public bool ResetParallax;

    public static GameController instance;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
    }

    public void Update()
    {
        if (ResetParallax == true)
        {
            StartCoroutine("RotinaReseteParallax");
        }
    }

    public void ActivePauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);    
    }

    public void ExitPauseButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void ResetButton(int i)
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(i);
    }

    public void GetCoin()
    {
        Score++;

        ScoreText.text = "X " + Score.ToString();
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator Rotina()
    {
        yield return new WaitForSeconds(1f);
        ShowGameOver();
    }

    IEnumerator RotinaReseteParallax()
    {
        yield return new WaitForSeconds(0.5f);
        ResetParallax = false;
    }

    public void LostLife()
    {
        Life--;
        if (Life >= 1)
        {
            Player.transform.position = new Vector3(CheckPoint.transform.position.x, CheckPoint.transform.position.y, 0f);
            Bg.transform.position = new Vector3(BgPosition.transform.position.x, 0f, 0f);
            Clouds.transform.position = new Vector3(CloudPosition.transform.position.x,0f, 0f);
            ResetParallax = true;

            lifeText.text = "X " + Life.ToString();
        }
        if (Life <= 0)
        {
            StartCoroutine("Rotina");
        }
    }
}
