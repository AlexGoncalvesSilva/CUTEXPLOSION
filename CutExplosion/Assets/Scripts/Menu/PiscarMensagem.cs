using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiscarMensagem : MonoBehaviour
{
    public GameObject text;

    public float i;

    private bool Piscar;

    private void Start()
    {
        Piscar = true;
    }

    private void Update()
    {
        if (Piscar == true)
        {
            StartCoroutine("RotinaParaPiscar");
        }
        if (Piscar == false)
        {
            StartCoroutine("RotinaParaPiscar2");
        }
    }

    IEnumerator RotinaParaPiscar()
    {
        yield return new WaitForSeconds(1f);
        text.SetActive(false);
        Piscar = false;
    }

    IEnumerator RotinaParaPiscar2()
    {
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        Piscar = true;
    }
}
