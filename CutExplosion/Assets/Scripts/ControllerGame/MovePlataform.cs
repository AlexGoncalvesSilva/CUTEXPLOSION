using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{

    [SerializeField] private float SpeedHorizontal;
    [SerializeField] private float i;


    private bool PlayerOnPlataform;
    private bool MoveForRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOnPlataform == true)
        {
            MovePlataformHorizontal();
            StartCoroutine("RotinaForVelocity");
            StartCoroutine("RotinaForBool");
        }
    }

    void MovePlataformHorizontal()
    {
        if (MoveForRight == true)
        {
            Vector3 movement = new Vector3(1f, 0f, 0f);
            transform.position += movement * SpeedHorizontal * Time.deltaTime;
        }
        if (MoveForRight == false)
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * SpeedHorizontal * Time.deltaTime;
        }
    }

    IEnumerator RotinaForVelocity()
    {
        yield return new WaitForSeconds(i);
        MoveForRight = false;
    }

    IEnumerator RotinaForBool()
    {
        yield return new WaitForSeconds(2*i);
        PlayerOnPlataform = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerOnPlataform = true;
            MoveForRight = true;
            Debug.Log("PLayer em cima");
        }
    }
}
