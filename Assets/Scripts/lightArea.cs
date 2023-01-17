using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class lightArea : MonoBehaviour
{
    public GameObject LightPrefab;

    public UnityEvent onLightArea;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(LightPrefab, collision.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<PlayerMovement>().inMovement = false;

            onLightArea.Invoke();
        }
    }

}
