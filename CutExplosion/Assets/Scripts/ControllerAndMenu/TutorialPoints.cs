using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPoints : MonoBehaviour
{
    public GameObject thisBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (TutorialController.instance.i == 0)
            {
                TutorialController.instance.Tut1Panel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Tut 1");
                thisBox.SetActive(false);
            }
            if (TutorialController.instance.i == 1)
            {
                TutorialController.instance.Tut2Panel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Tut 2");
                thisBox.SetActive(false);
            }
            if (TutorialController.instance.i == 2)
            {
                TutorialController.instance.Tut3Panel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Tut 3");
                thisBox.SetActive(false);
            }
            if (TutorialController.instance.i == 3)
            {
                TutorialController.instance.Tut4Panel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Tut 4");
                thisBox.SetActive(false);
            }  
        }
    }
}
