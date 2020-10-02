using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ballRigid;
    public float rotationSpeed = 2f;
    public float forceRate = 40f;
    public LineRenderer ballLine;
    private float holdDownStartTime;
    public Touch touch;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ballRigid.position;
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
        }
        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
            if (yRot < -60f)
            {
                yRot = -60f;
            }
            if (yRot > 90f)
            {
                yRot = 90f;
            }
            if (xRot > 120f)
            {
                xRot = 120f;
            }
            if (xRot < -120f)
            {
                xRot = -120f;
            }
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f * Time.deltaTime);
            ballLine.gameObject.SetActive(true);
            ballLine.SetPosition(0, transform.position);
            ballLine.SetPosition(1, transform.position + transform.forward * 6f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            ballRigid.velocity = transform.forward * calculateForce(holdDownTime);
            ballLine.gameObject.SetActive(false);
        }
#endif
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ballLine.gameObject.SetActive(false);
                holdDownStartTime = Time.time;
                xRot = 0f;
                yRot = 0f;

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                xRot +=  touch.deltaPosition.x/rotationSpeed;
                yRot += touch.deltaPosition.y/rotationSpeed;
                if (yRot < -30f)
                {
                    yRot = -30f;
                }
                if (yRot > 45f)
                {
                    yRot = 45f;
                }
                if (xRot > 90f)
                {
                    xRot = 90f;
                }
                if (xRot < -90f)
                {
                    xRot = -90f;
                }
                transform.rotation = Quaternion.Euler(yRot, -xRot, 0f * Time.deltaTime);
                ballLine.gameObject.SetActive(true);
                ballLine.SetPosition(0, transform.position);
                ballLine.SetPosition(1, transform.position + transform.forward * 8f);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ballRigid.velocity = transform.forward * calculateForce(holdDownStartTime);
                ballLine.gameObject.SetActive(false);
               

            }
        }
    }

    float calculateForce(float holdDownTime)
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdDownTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * forceRate;
        //Debug.Log(force);
        if(force>25)
        {
            force = 25;
        }
        return force;

    }

    void LateUpdate()
    {

    }
  
}

