using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wall : MonoBehaviour, IChangeColor
{
    Color m_C;
    int m_Red;
    int m_Blue;
    int m_Green;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ActivateWall(other));
    }
    //Used for changing playing ball's color change
    public IEnumerator ActivateWall(Collider other)
    {
        m_C = other.gameObject.GetComponent<Renderer>().material.color;
        m_Red = Random.Range(0, 255);
        m_Blue = Random.Range(0, 255);
        m_Green = Random.Range(0, 255);
        other.gameObject.GetComponent<Renderer>().material.color = new Color(m_Red, m_Blue, m_Green);
        yield return new WaitForSeconds(1);
        other.gameObject.GetComponent<Renderer>().material.color = m_C;
        yield return new WaitForSeconds(1);
    }
}
