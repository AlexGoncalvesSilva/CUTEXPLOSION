using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rig;

    [SerializeField] private float Speed;
    [SerializeField] private float Radius;

    private bool playerIsClose;

    public Transform Point;
    public GameObject StartPos;
    public LayerMask PlayerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerIsClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        SeePlayer();
        if (playerIsClose == true) { Move(); }
    }

    void Move()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Speed * Time.deltaTime;
    }

    void SeePlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(Point.position, Radius, PlayerLayer);

        if (hit != null)
        {
            playerIsClose = true;
        }
        if (hit == null)
        {
            playerIsClose = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
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