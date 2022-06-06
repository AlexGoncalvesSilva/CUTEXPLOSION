using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float DownForce;
    [SerializeField] private float DashForce;
    [SerializeField] private float StartDashTimer;
    [SerializeField] private int life;
    [SerializeField] private float Radius;
    private float CurrentDashTimer;

    private bool isGround;
    private bool canDash;
    private bool isDead;
    private bool isJumping;
    public bool canDie;

    private Rigidbody2D rig;
    public Animator anim;

    public Transform Point;
    public LayerMask GroundMask;

    public static PlayerBasic instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rig = GetComponent<Rigidbody2D>();
        isGround = true;
        canDash = true;
        isDead = false;
        canDie = true;
        life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ForCanNotJumpInAir();
        if (canDash == false)
        {
            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                canDash = true;
            }
        }

        if(!isJumping && canDash && !isDead)
        {
            anim.SetInteger("Transition", 0);
        }
    }

    void FixedUpdate()
    {

    }

    void MovePlayer()
    {
        if (life >= 1)
        {
            Vector3 movement = new Vector3(1f, 0f, 0f);
            transform.position += movement * Speed * Time.deltaTime;
        }

    }

    public void Jump()
    {
        if (isGround == true)
        {
            isJumping = true;
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            anim.SetInteger("Transition", 1);
            isGround = false;
            StartCoroutine("RotinaJump");
        }
    }

    IEnumerator RotinaJump()
    {
        yield return new WaitForSeconds(1f);
        anim.SetInteger("Transition", 0);
    }

    public void Down()
    {
        rig.AddForce(Vector2.down * DownForce, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        if (canDash == true)
        {
            rig.AddForce(Vector2.right * DashForce, ForceMode2D.Impulse);
            anim.SetBool("isDashing", true);
            canDash = false;
            CurrentDashTimer = StartDashTimer;
            canDie = false;
            StartCoroutine("Rotina");
            StartCoroutine("RotinaCanDie");
        }
    }

    IEnumerator Rotina()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isDashing", false);
    }
    
    IEnumerator RotinaCanDie()
    {
        yield return new WaitForSeconds(1.1f);
        canDie = true;
    }

    void ForCanNotJumpInAir()
    {
        Collider2D hit = Physics2D.OverlapCircle(Point.position, Radius, GroundMask);
        if(hit == null)
        {
            isGround = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isGround = true;
            isJumping = false;
        }

        if (collision.gameObject.layer == 8)
        {
            if (canDie == true)
            {
                GameController.instance.LostLife();
                life--;

                if (life <= 0)
                {
                    isDead = true;
                    anim.SetInteger("Transition", 2);
                }
            }  
        }

        if (collision.gameObject.layer == 13)
        {
            if (canDie == true)
            {
                GameController.instance.LostLife();
                life--;

                if (life <= 0)
                {
                    isDead = true;
                    anim.SetInteger("Transition", 2);
                }
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
        //if(collision.gameObject.layer == 14)
        //{
        //    Debug.Log("Tutorial");
        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Point.position, Radius);
    }
}
