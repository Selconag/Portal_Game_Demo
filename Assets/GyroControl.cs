using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    public bool gyroEnabled = true;
    private Gyroscope gyro;
    private Quaternion rot;
    private GameObject Container;

    // Start is called before the first frame update
    void Start()
    {
        Container = new GameObject("Camera Container");
        Container.transform.position = transform.position;
        transform.SetParent(Container.transform); 
        gyroEnabled = EnableGyro();
        //this.transform.position = transform.position;

    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        //Container.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        rot = new Quaternion(0, 0, 1, 0);


        return false;
    }

    // Update is called once per frame


    void Update()
    {
        if (gyro.enabled)
        {
            transform.localRotation = gyro.attitude * rot;

        }
    }
}
