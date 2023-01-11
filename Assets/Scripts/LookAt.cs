using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject Parent;


    public Vector3 offset = new Vector3(0, 0, -10);
    private void Update()
    {
        transform.position = Parent.transform.position + offset;
    }
}
