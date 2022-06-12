using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControllerMage : MonoBehaviour
{
    public GameObject Tut1Panel;

    public static TutorialControllerMage instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ContinueButton()
    {
        Time.timeScale = 1;

        Tut1Panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
           Tut1Panel.SetActive(true);
           Time.timeScale = 0;
           Debug.Log("Tut 1");
           this.gameObject.SetActive(false);
        }
    }
}
