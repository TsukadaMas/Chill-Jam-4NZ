using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightArea : MonoBehaviour
{
    public GameObject LightPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(LightPrefab, collision.transform.position, Quaternion.identity);
        }
    }

}
