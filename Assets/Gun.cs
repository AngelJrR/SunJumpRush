using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    private Vector2 mousePos;
    private Vector2 playerPos;
    public float degree;
    public int type;
    public GameObject player;
    public float shootDelay;
    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - degree;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            //Quaternion gunRot= transform.rotation - 180f;
            //transform.rotation = Quaternion.AngleAxis(30, Vector3.forward);
        }
        else
        {
            //Debug.Log("hi");
            //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //playerPos = Camera.main.ScreenToWorldPoint(player.transform.position);
            //float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg - degree;
            float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - degree;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        /*
        shootTimer += Time.deltaTime;

        if(shootTimer >= shootDelay)
            shootTimer = 0;
        */
        if (Input.GetKeyDown(KeyCode.Mouse0) && shootTimer >= shootDelay)
        {
            // Quaternion yea = transform.rotation + transform.localRotation;
            //transform.rotation = Quaternion.AngleAxis(130, Vector3.forward);
            Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0;
        }
        else 
            shootTimer += Time.deltaTime;


        /*
        else if (Input.GetKeyDown(KeyCode.Mouse0) && type == 1)
        {
            // Quaternion yea = transform.rotation + transform.localRotation;
            //transform.rotation = Quaternion.AngleAxis(130, Vector3.forward);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        */
        /*{
            float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - degree;
            transform.localRotation = Quaternion.Euler(0, 0, angle);

            Instantiate(bullet, transform.position, transform.rotation);
        }
      */
    }
}
