using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollision : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerCirc;
    void Start()
    {
        playerCirc = GameObject.Find("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<BoxCollider2D>().isTrigger)
        {
            Debug.Log("Collision");
        }
    }
}
