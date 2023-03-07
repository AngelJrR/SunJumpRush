using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Rigidbody2D playerBody;
    public float moveSpeed;
    public float jumpForce;
    Vector2 direction;
    bool onGround = false;
    public BoxCollider2D playerCollider;
    public int health = 10;
    public int damage = 1;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Jump") && onGround)
        {
            playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Debug.Log(health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;

    }

    void FixedUpdate()
    {
        playerBody.AddForce(direction.x * Vector2.right * moveSpeed);
        if(direction.y < 0)
        playerBody.AddForce(-direction.y * Vector2.down * moveSpeed);
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
            //Debug.Log("hi");
        }

        if (collision.tag == "EnemyBullet")
        {
            health -= damage;
           // Debug.Log("helo");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bottom")
        {
            //playerCollider.enabled = true;
            Invoke("stupid", 0.2f);
            onGround = false;
            //Debug.Log("hllo");
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

    public void stupid()
    {
        playerCollider.enabled = true;
    }

}
