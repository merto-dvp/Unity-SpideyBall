using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;
    public float smoothSpeed = 0.125f;
    public Transform target;
    public GameObject rotAxis;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        //yaw = Mathf.Clamp(yaw, -90f, 90f);
        //pitch = Mathf.Clamp(pitch, -60f, 90f);

        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        transform.position = new Vector3(target.position.x, target.position.y + 16, target.position.z - 12);
        float x= transform.rotation.x;
        float y= transform.rotation.y;
        float z = transform.rotation.z;
        transform.rotation = new Quaternion(rotAxis.transform.rotation.x/2, rotAxis.transform.rotation.y/2, rotAxis.transform.rotation.z , 1 );
        //transform.rotation = new Quaternion(x, y, z , 1);
        //transform.rotation = new Quaternion(0,0,0,1);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 100 * Time.deltaTime);
    }
    void FixedUpdate()
    {
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position), 5);
        //Vector3 targetDir = transform.TransformDirection(target.position);//this is merely a direction now
        //transform.Translate(targetDir.normalized * 5);//speed applied here instead
    }
    void LateUpdate()
    {
        //transform.position = target.position;
    }

}
