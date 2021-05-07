using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1f);
    }
}
