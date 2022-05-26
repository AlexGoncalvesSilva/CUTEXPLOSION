using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rig;

    [SerializeField] private float Speed;
    [SerializeField] private float Radius;

    private bool playerIsClose;
    private bool mageIsClose;

    public Transform Point;
    public GameObject StartPos;
    public LayerMask PlayerMageLayer;
    public LayerMask PlayerBasicLayer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerIsClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        SeePlayerMage();

        if (playerIsClose == true) 
        {
            Move(); 
            Debug.Log("Tá vendo o player"); 
        }
        if (mageIsClose == true)
        {
            Debug.Log("Na área");
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Speed * Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
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
                Destroy(this.gameObject, 0.08f);
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