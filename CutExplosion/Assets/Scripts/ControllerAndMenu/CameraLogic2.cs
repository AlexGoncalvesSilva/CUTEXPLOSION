using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic2 : MonoBehaviour
{
    [SerializeField] private float CameraSpeed;
    [SerializeField] private float CameraDistance;
    private Transform player;
    private Transform playerChanged;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ChangeMecanic.instance.Changed == true)
        {
            playerChanged = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("Deveria tá pegando");
            CameraMoveWhenChanged();
        }
        if(ChangeMecanic.instance.Changed == false)
        {
            CameraMove();
        }

    }

    private void Update()
    {

    }

    void CameraMove()
    {
        Vector3 NewCamPosition = new Vector3(player.position.x + CameraDistance, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, NewCamPosition, CameraSpeed * Time.deltaTime);
    }
    void CameraMoveWhenChanged()
    {
        Vector3 NewCamPosition = new Vector3(playerChanged.position.x + CameraDistance, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, NewCamPosition, CameraSpeed * Time.deltaTime);
    }
}