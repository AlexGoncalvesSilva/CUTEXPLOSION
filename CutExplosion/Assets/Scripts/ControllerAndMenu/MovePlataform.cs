using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{

    [SerializeField] private float SpeedHorizontal;
    [SerializeField] private float i;


    private bool PlayerOnPlataform;

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
        }
    }

    void MovePlataformHorizontal()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * SpeedHorizontal * Time.deltaTime;
    }

    IEnumerator RotinaForBool()
    {
        yield return new WaitForSeconds(i);
        PlayerOnPlataform = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerOnPlataform = true;
            Debug.Log("PLayer em cima");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            SpeedHorizontal = -SpeedHorizontal;
        }
    }
}
