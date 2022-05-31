using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMecanic : MonoBehaviour
{

    public GameObject BasicPlayer;
    public GameObject MagePlayer;
    public Transform SpawnPosition;

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
            BasicPlayer.SetActive(false);
            MagePlayer.SetActive(true);
        }
        if (collision.gameObject.layer == 10)
        {
            BasicPlayer.SetActive(true);
            MagePlayer.SetActive(false);
        }   
    }
}
