using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyBody;
    public float enemySpeed;
    public float enemyJump;
    public GameObject player;
    bool onGround = false;
    public GameManager gameManager;
    float fTimer = 0f;
    public int type;
    string fReady = "notready";
    bool beginnin = true;
    public float direction;
    public float fSpeed;
    public GameObject bullet;
    public float degree;
    float sTimer = 0f;
    float jTimer = 0f;
    bool killable = true;
    public Controller playerController;
    public Collider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<Controller>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
       // if(type == 2)
        //transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(0, 18), enemySpeed * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
            goomb();
        else if (type == 2)
            flyer();
        else if (type == 3)
            mage();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpPad") 
        {
            enemyBody.AddForce(Vector2.up * enemyJump, ForceMode2D.Impulse);
        }

        if (collision.tag == "Sun")
        {
            gameManager.enemiesKilled++;

            Destroy(gameObject);
        }

        if (collision.tag == "Bullet" && killable)
        {
            gameManager.enemiesKilled++;

            Destroy(gameObject);
        }

        if (collision.tag == "Bottom")
        {
            enemyCollider.enabled = false;
            //onGround = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bottom")
        {
            enemyCollider.enabled = true;
           // onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        if (collision.gameObject.tag == "Platform" && type != 2)
        {
            transform.parent = collision.gameObject.transform;
        }

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        transform.parent = null;
    }

    public void flyer()
    {
        
        
        float shootF = Random.Range(2, 8);
        sTimer += Time.deltaTime;
        if (sTimer >= shootF)
        {
            sTimer = 0;
            float shootsF = Random.Range(1, 5);
            for(int i = 0; i < shootsF; i++)
            shoot();
        }
        

        if (transform.position != new Vector3(0, 18, 0) && beginnin)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(0, 18), enemySpeed * Time.deltaTime);
            //Debug.Log("couont");
            //fReady++;
            //Debug.Log(fReady); 
        }
        else
        {

            beginnin = false;
            float spawnF = Random.Range(2, 8);
            fTimer += Time.deltaTime;
            if (fTimer >= spawnF)
            {
                fTimer = 0;
                //Debug.Log("ready");
                if(fReady == "notready")
                fReady = "ready";


            }
            //        sideVariance = Random.Range(-18, 18);

            if (fReady == "ready")
            {
                fReady = "ongoing";
                direction = Random.Range(-30, 30);
                fSpeed = Random.Range(2, 7);


            }

            if (transform.position != new Vector3(direction, 18, 0) && fReady == "ongoing")
            {
                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(direction, 18), fSpeed * Time.deltaTime);
            }
            else
                fReady = "notready";

            //enemyBody.AddForce(direction * Vector2.right * enemySpeed);
        }


    }

    public void shoot()
    {
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - degree;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

            Instantiate(bullet, transform.position, transform.rotation);

    }

    public void goomb()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);

    }

    public void mage()
    {
        playerController.damage = 2;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        float jumpM = Random.Range(2, 8);
        jTimer += Time.deltaTime;
        if (jTimer >= jumpM && onGround)
        {
            jTimer = 0;
            enemyBody.AddForce(Vector2.up * enemyJump, ForceMode2D.Impulse);


        }
    }
}
