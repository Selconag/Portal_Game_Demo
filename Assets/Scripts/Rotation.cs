using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for GameGround's rotation
public class Rotation : MonoBehaviour
{
    public Joystick Joystick;
    public JoyButton Joybutton;
    [SerializeField]private float RotateSpeed = 0.5f;
    private void Start()
    {
        Joystick = FindObjectOfType<Joystick>();
        Joybutton = FindObjectOfType<JoyButton>();

    }
    void Update()
    {
        this.gameObject.transform.rotation = new Quaternion(Joystick.Horizontal * RotateSpeed, Joystick.Vertical * RotateSpeed, 0,1);
    }
}
