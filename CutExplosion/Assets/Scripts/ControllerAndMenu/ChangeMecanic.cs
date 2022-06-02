using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMecanic : MonoBehaviour
{

    public GameObject BasicPlayerr;
    public GameObject MagePlayerr;

    public bool Changed;

    public static ChangeMecanic instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotinaChangePlayerForMage()
    {
        yield return new WaitForSeconds(0.4f);
        BasicPlayerr.SetActive(false);
        MagePlayerr.SetActive(true);
    }

    IEnumerator RotinaChangePlayerForBasic()
    {
        yield return new WaitForSeconds(0.4f);
        BasicPlayerr.SetActive(true);
        MagePlayerr.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine("RotinaChangePlayerForMage");
            Changed = true;
            Debug.Log("Tocou");
        }
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine("RotinaChangePlayerForBasic");
            Changed = true;
            Debug.Log("Tocou");
        }
    }
}
