using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBolhas : MonoBehaviour
{
    public GameObject[] Bolhas;
    public Transform SpawnPosition;

    private float TimerInitial;
    [SerializeField] private float TimerFinal;

    public bool InMenu;

    int random;

    public static SpawnBolhas instance;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBarrel();
    }

    void SpawnBarrel()
    {
        random = Random.Range(0, 2);
        TimerInitial += Time.deltaTime;

        if (TimerInitial >= TimerFinal)
        {
         GameObject bolhas  = GameObject.Instantiate(Bolhas[random], SpawnPosition.position, SpawnPosition.rotation);
         TimerInitial = 0;
         Destroy(bolhas, 10f);   
        }
    }
}
