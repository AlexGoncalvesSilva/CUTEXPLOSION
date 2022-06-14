using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private float BgSpeed;
    [SerializeField] private float BgDistance;
    private Transform player;

    public float i;
    public static Parallax instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        BgDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BgMove();
        if (GameController.instance.ResetParallax == true)
        {
            BgDistance = 0;
        }
    }

    void LateUpdate()
    {
        if (GameController.instance.ResetParallax == false)
        {
            BgDistance += -Time.deltaTime / i;
        }
    }

    void BgMove()
    {
        Vector3 NewBgPosition = new Vector3(player.position.x + BgDistance, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, NewBgPosition, BgSpeed * Time.deltaTime);
    }
}