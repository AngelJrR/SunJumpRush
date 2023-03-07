using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float flySpeed;
    Rigidbody2D bulletBody;

    // Start is called before the first frame update
    void Start()
    {
    bulletBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.up * flySpeed * Time.deltaTime;

        //transform.Translate(transform.forward * flySpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        bulletBody.velocity = -transform.right * flySpeed;
    }
}
