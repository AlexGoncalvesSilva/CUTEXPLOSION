using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float DownForce;

    private bool isGround;

    Rigidbody2D rig;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(1f,0f,0f);
        transform.position += movement * Speed * Time.deltaTime;
    }

    public void JumpButton()
    {
        if (isGround == true)
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    public void Down()
    {
        rig.AddForce(Vector2.down * DownForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isGround = true;
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Tocou no inimigo");
        }
    }
}
