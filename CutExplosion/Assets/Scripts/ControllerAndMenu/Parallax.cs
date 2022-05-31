using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    //[SerializeField] private float Speed;
    //[SerializeField] private float DashForce;
    //private Rigidbody2D rig;

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
        Vector3 NewCamPosition = new Vector3(player.position.x + BgDistance, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, NewCamPosition, BgSpeed * Time.deltaTime);
    }
}
