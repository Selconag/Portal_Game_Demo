using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classes for traps and other interactable objects
public class Trap : MonoBehaviour
{
    GameManager G;
    Color C;
    int Red;
    int Blue;
    int Green;
    private void Start()
    {
        G = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (this.gameObject.name)
        {
            case "Wall":
                //Change Color Randomly
                StartCoroutine(Change_Color(other));
                break;
            case "Spiketrap":
                Destroy(other.gameObject);
                G.Game_Resolution(false);
                break;
            case "Bouncertrap":
                other.attachedRigidbody.AddRelativeForce(Vector3.forward * 500f);
                break;
            case "Firetrap":
                Destroy(other.gameObject);
                G.Game_Resolution(false);
                break;
            case "Needle":
                Destroy(other.gameObject);
                G.Game_Resolution(false);
                break;
            case "Cutter":
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
    //Used for changing playing ball's color change
    IEnumerator Change_Color(Collider col)
    {
        C = col.gameObject.GetComponent<Renderer>().material.color;
        Red = Random.Range(0, 255);
        Blue = Random.Range(0, 255);
        Green = Random.Range(0, 255);
        col.gameObject.GetComponent<Renderer>().material.color = new Color(Red, Blue, Green);
        yield return new WaitForSeconds(1);
        col.gameObject.GetComponent<Renderer>().material.color = C;
        yield return new WaitForSeconds(1);
    }
}
