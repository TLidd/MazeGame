using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Brackey's tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
public class CameraController : MonoBehaviour
{

    public Transform playerBody;

    public float sensitivity = 100f;
    public float finalYRot = 0;
    public bool enableVerticalCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        finalYRot -= yRot;
        finalYRot = Mathf.Clamp(finalYRot, -90, 90);

        if (enableVerticalCamera)
        {
            //using quaternion so we don't infinitely go past 90
            transform.localRotation = Quaternion.Euler(finalYRot, 0, 0);
        }


        //X movement
        playerBody.Rotate(Vector3.up * xRot);
    }
}
