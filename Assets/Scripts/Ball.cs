using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private float HoverAmount = 3f;
    void Update()
    {
        //The object is stuck at the surface's collider so we need to hover it
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * HoverAmount);
    }
}
