using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMage : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float flyForce;

    Rigidbody2D rig;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Speed * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            rig.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse);
            //Vector3 fly = new Vector3(0f, 1f, 0f);
            //transform.position += fly * flyForce * Time.deltaTime;
            Debug.Log("clicou");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameController.instance.LostLife();
        }
    }
}