using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private float CameraSpeed;
    [SerializeField] private float CameraDistance;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 NewCamPosition = new Vector3(player.position.x + CameraDistance, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, NewCamPosition, CameraSpeed * Time.deltaTime);
    }
}
