using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolhas : MonoBehaviour
{

    [SerializeField] private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, 1f, 0f);
        transform.position += movement * Speed * Time.deltaTime;
    }
}
