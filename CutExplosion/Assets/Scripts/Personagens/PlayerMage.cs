using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMage : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float flyForce;
    [SerializeField] private int life;

    Rigidbody2D rig;

    public Animator anim;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        life = 5;
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
            anim.SetInteger("Transition", 1);
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameController.instance.LostLife();
            if (life <= 0)
            {
                anim.SetInteger("Transition", 2);
            }
        }
        if (collision.gameObject.layer == 13)
        {
            GameController.instance.LostLife();
            if (life <= 0)
            {
                anim.SetInteger("Transition", 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameController.instance.GetCoin();
            Destroy(collision.gameObject, 0.1f);
        }
    }
}