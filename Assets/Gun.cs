using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    private Vector2 mousePos;
    public float degree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - degree;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        //Quaternion gunRot= transform.rotation - 180f;
        //transform.rotation = Quaternion.AngleAxis(30, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           // Quaternion yea = transform.rotation + transform.localRotation;
            //transform.rotation = Quaternion.AngleAxis(130, Vector3.forward);
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
