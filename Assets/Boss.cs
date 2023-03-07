using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Rigidbody2D playerBody;
    public float moveSpeed;
    public float jumpForce;
    Vector2 direction;
    bool onGround = false;
    public BoxCollider2D playerCollider;
    public int health = 10;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        playerBody.AddForce(direction.x * Vector2.right * moveSpeed);

        // playerBody.MovePosition(movement);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sun")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Bottom")
        {
            playerCollider.enabled = false;
        }
        if (collision.tag == "EnemyBullet")
        {
            health -= damage;
            Debug.Log("helo");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bottom")
        {
            playerCollider.enabled = true;
            onGround = false;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.gameObject.transform;
        }
        /*
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("world");
            health -= damage;
        }
        */
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        transform.parent = null;
    }

}
