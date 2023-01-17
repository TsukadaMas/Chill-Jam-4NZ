using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 mousePos;

    public GameObject directionIndicator;
    public GameObject location;

    public float movementForce = 5f;

    [System.NonSerialized]
    public bool inMovement;
    
    private Vector3 _respawnLocation;

    public UnityEvent onThrow;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        _respawnLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location.transform.position = mousePos;
        if (Input.GetButtonDown("Fire1") && !inMovement)
        {
            inMovement = true;
            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - mousePos;
            rb.AddForce(direction.normalized * movementForce, ForceMode2D.Impulse);
            onThrow.Invoke();
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        directionIndicator.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)); //angle
    }

    void OnDrawGizmos()
    {
        Vector3 p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(p2, 0.1F);
    }

    public void Respawn() { 
        rb.velocity = new Vector2(0, 0);
        inMovement = false;

        gameObject.transform.position = _respawnLocation;
    }

}
