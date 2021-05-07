using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "Spiketrap")
        Destroy(other.gameObject);
        else
        {
            other.attachedRigidbody.AddRelativeForce(Vector3.back * 2000f);
            //other.attachedRigidbody.AddExplosionForce(100f,other.gameObject.transform.position,30f);

        }
    }
}
