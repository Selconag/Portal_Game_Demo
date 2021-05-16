using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    protected bool Pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = true;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
