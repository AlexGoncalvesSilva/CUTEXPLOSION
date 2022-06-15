using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RotinaCutscene");
    }

    IEnumerator RotinaCutscene()
    {
        yield  return new WaitForSeconds(57.5f);
        SceneManager.LoadScene(1);
    }
    public void PassCutscene()
    {
        SceneManager.LoadScene(1);
    }
}
