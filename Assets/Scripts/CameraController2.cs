using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 1;
    public Transform target, player;
    float mouseX, mouseY;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y+6, target.position.z-12);
       
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -30, 90);
        mouseX = Mathf.Clamp(mouseX, -30, 90);
        transform.LookAt(target);
        target.rotation=Quaternion.Euler(mouseY,mouseX,0);
        player.rotation=Quaternion.Euler(0,mouseX,0);

    }
    private void LateUpdate()
    {
        CamControl();
    }
    void playerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(h, 0f, v * speed * Time.deltaTime);
        transform.Translate(playerMovement, Space.Self);
    }
}
