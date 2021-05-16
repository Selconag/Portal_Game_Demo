using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for GameGround's rotation
public class Rotation : MonoBehaviour
{
    public Joystick Joystick;
    public JoyButton Joybutton;
    [SerializeField]protected float RotateSpeed = 0.5f;
    private void Start()
    {
        Joystick = FindObjectOfType<Joystick>();
        Joybutton = FindObjectOfType<JoyButton>();

    }

    //Need to add 2 joysticks 
    //1 joystick only works with horizontal
    //1 joystick will only works with vertical
    //              OR
    //Work with 4 different buttons
    void Update()
    {
        //this.gameObject.transform.rotation= new Quaternion(Joystick.Horizontal * RotateSpeed, Joystick.Vertical * RotateSpeed, 0,1);
        this.gameObject.transform.Rotate(-Joystick.Horizontal * RotateSpeed, 0, -Joystick.Vertical * RotateSpeed);
    }
}
