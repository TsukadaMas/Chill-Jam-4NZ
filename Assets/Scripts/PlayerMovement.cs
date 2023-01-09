using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 mousePos;

    public GameObject directionIndicator;
    public GameObject location;

    public float movementForce = 5f;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location.transform.position = mousePos;
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - mousePos;
            rb.AddForce(direction.normalized * movementForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        directionIndicator.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));//angle;
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Vector2 direction = new Vector2(transform.position.x, transform.position.y) - mousePos;
        //    rb.AddForce(direction.normalized * movementForce, ForceMode2D.Impulse);
        //}
    }

    void OnDrawGizmos()
    {
        Vector3 p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(p2, 0.1F);
    }

}
