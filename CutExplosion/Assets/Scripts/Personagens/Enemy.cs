using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rig;

    [SerializeField] private float Speed;
    [SerializeField] private float SpeedVertical;
    [SerializeField] private float Radius;

    private bool playerIsClose;
    private bool mageIsClose;
    private bool isDead;

    public bool trueIsBasicLvl;

    public Transform Point;
    public GameObject StartPos;
    public Animator anim;
    public LayerMask PlayerMageLayer;
    public LayerMask PlayerBasicLayer;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rig = GetComponent<Rigidbody2D>();
        playerIsClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        SeePlayerMage();
        SeePlayerBasic();

        if (playerIsClose == true) 
        {
            MoveToBasic(); 
            Debug.Log("Tá vendo o player");
            if (!isDead)
            {
                anim.SetInteger("Transition", 1);
            }
        }

        if (mageIsClose == true)
        {
            MoveToMage();
            Debug.Log("Na área");
            anim.SetInteger("Transition", 1);
        }

        if (!playerIsClose && !mageIsClose)
        {
            anim.SetInteger("Transition", 0);
        }

        if (trueIsBasicLvl == true) 
        {
            if (PlayerBasic.instance.hitTrap == true)
            {
                transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
            }
        }
        if (trueIsBasicLvl == false)
        {
            if (PlayerMage.instance.hitTrap == true)
            {
                transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
            }
        }
        
    }

    private void FixedUpdate()
    {
    }

    void MoveToBasic()
    {
        if (isDead == false)
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * Speed * Time.deltaTime;
        }
        if (isDead == true)
        {
            Vector3 movement = new Vector3(1f, 0f, 0f);
            transform.position += movement * 0.3f * Time.deltaTime;
        }

    }

    void MoveToMage()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Speed * Time.deltaTime;

        Vector3 upAndDown = new Vector3(0f, 1f, 0f);
        transform.position += upAndDown * SpeedVertical * Time.deltaTime;

        //rig.velocity = new Vector2(Speed, 0);

        if (transform.position.y >= 5)
        {
            SpeedVertical = -SpeedVertical;
        }
        if (transform.position.y <= -5.5)
        {
            SpeedVertical = -SpeedVertical;
        }
    }

    void SeePlayerBasic()
    {
        Collider2D hit = Physics2D.OverlapCircle(Point.position, Radius, PlayerBasicLayer);

        if (hit != null)
        {
            playerIsClose = true;
        }
        else
        {
            playerIsClose = false;
        }
    }

    void SeePlayerMage()
    {
        Collider2D hit = Physics2D.OverlapCircle(Point.position, Radius, PlayerMageLayer);

        //andar para o mago

        if (hit != null)
        {
            mageIsClose = true;
        }
        else
        {
            mageIsClose = false;
        }
    }

    IEnumerator RotinaAnim()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("IsDead", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.layer == 6)
        //{
        //    if (PlayerBasic.instance.canDie == true)
        //    {
        //        if (GameController.instance.Life >= 1)
        //        {
        //            transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
        //        }
        //    }
        //    if (PlayerBasic.instance.canDie == false)
        //    {
        //        Destroy(this.gameObject, 1f);
        //        anim.SetBool("IsDead", true);
        //    }
           
        //}

        if (collision.gameObject.layer == 10)
        {
            if (GameController.instance.Life >= 1)
            {
                transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (PlayerBasic.instance.canDie == true)
            {
                if (GameController.instance.Life >= 1)
                {
                    transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
                }
            }
            if (PlayerBasic.instance.canDie == false)
            {
                Destroy(this.gameObject, 1.5f);
                isDead = true;
                anim.SetBool("IsDead", true);
                StartCoroutine("RotinaAnim");
            }

        }

        if (collision.gameObject.layer == 10)
        {
            if (GameController.instance.Life >= 1)
            {
                transform.position = new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, 0f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Point.position, Radius);
    }
}