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
    public int health = 30;
    public int damage = 1;
    public GameObject player;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        playerBody.AddForce(direction.x * Vector2.right * moveSpeed);
        
        if(transform.position.y <= -14.5)
        {
                playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
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

        if (collision.tag == "Bullet")
        {
            health -= damage;
        }


        if (collision.tag == "JumpPad")
        {
            playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bottom")
        {
            Invoke("stupid", 2f);
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

    public void stupid()
    {
        playerCollider.enabled = true;
    }
}
