using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMage : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float flyForce;
    [SerializeField] private int life;

    private bool isFlying;
    private bool isDead;
    public bool hitTrap;

    Rigidbody2D rig;

    public Animator anim;

    private AudioController audioController;

    public static PlayerMage instance;

    void Start()
    {
        instance = this;
        hitTrap = false;
        audioController = GetComponent<AudioController>();
        isFlying = false;
        isDead = false;
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
            isFlying = true;
            anim.SetInteger("Transition", 1);
        }
        if (Input.touchCount <= 0)
        {
            isFlying = false;
        }
        if (isDead)
        {
            anim.SetInteger("Transition", 2);
        }
        if (!isFlying && !isDead)
        {
            anim.SetInteger("Transition", 0);
        }

    }

    IEnumerator RotinaForTrap()
    {
        yield return new WaitForSeconds(1.1f);
        hitTrap = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            audioController.PlaySFX(audioController.deadSound);
            GameController.instance.LostLife();
            life--;
            if (life <= 0)
            {
                audioController.PlaySFX(audioController.deadSound);
                anim.SetInteger("Transition", 2);
                isDead = true;
            }
        }
        if (collision.gameObject.layer == 13)
        {
            audioController.PlaySFX(audioController.deadSound);
            GameController.instance.LostLife();
            hitTrap = true;
            StartCoroutine("RotinaForTrap");
            life--;
            if (life <= 0)
            {
                audioController.PlaySFX(audioController.deadSound);
                isDead = true;
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
            audioController.PlaySFX(audioController.coinSound);
        }
    }
}