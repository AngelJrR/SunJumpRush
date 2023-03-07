using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public float fallSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sun")
        {
            Destroy(gameObject);
        }
    }

}
