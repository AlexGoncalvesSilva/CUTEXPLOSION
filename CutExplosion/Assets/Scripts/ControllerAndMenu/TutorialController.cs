using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    public GameObject Tut1Panel;
    public GameObject Tut2Panel;
    public GameObject Tut3Panel;
    public GameObject Tut4Panel;

    public int i;

    public static TutorialController instance;
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
        StartCoroutine("RotinaForI");
        Tut1Panel.SetActive(false);
        Tut2Panel.SetActive(false);
        Tut3Panel.SetActive(false);
        Tut4Panel.SetActive(false);
    }

    IEnumerator RotinaForI()
    {
        yield return new WaitForSeconds(0.5f);
        i++;
    }
}
