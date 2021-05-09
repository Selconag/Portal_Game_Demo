using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    GameManager G;
    private void Start()
    {
        G = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (this.gameObject.name)
        {
            case "Spiketrap":
                Destroy(other.gameObject);
                G.Game_Resolution(false);
                break;
            case "Bouncertrap":
                other.attachedRigidbody.AddRelativeForce(Vector3.back * 500f);
                break;
            case "Electrictrap":
                Destroy(other.gameObject);
                G.Game_Resolution(false);
                break;
            case "Portal":
                //Succes on level
                G.Game_Resolution(true);
                Destroy(other.gameObject);
                break;
        }
    }
}
