using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataformVertical : MonoBehaviour
{
    [SerializeField] private float SpeedVertical;
    [SerializeField] private float i;


    private bool PlayerOnPlataform;
    private bool MoveUp;

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
        if (MoveUp == true)
        {
            Vector3 movement = new Vector3(0f, 1f, 0f);
            transform.position += movement * SpeedVertical * Time.deltaTime;
        }
        if (MoveUp == false)
        {
            Vector3 movement = new Vector3(0f, -1f, 0f);
            transform.position += movement * SpeedVertical * Time.deltaTime;
        }
    }

    IEnumerator RotinaForVelocity()
    {
        yield return new WaitForSeconds(i);
        MoveUp = false;
    }

    IEnumerator RotinaForBool()
    {
        yield return new WaitForSeconds(2 * i);
        PlayerOnPlataform = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerOnPlataform = true;
            MoveUp = true;
            Debug.Log("PLayer em cima");
        }
    }
}
