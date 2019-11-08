using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerBody;

    public float sensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //float finalYRot = Mathf.Clamp(yRot, -90, 90);

        transform.Rotate(-Vector3.right * Mathf.Clamp(yRot, -90, 90));
        //transform.localRotation = Quaternion.Euler(finalYRot, 0, 0);
        //X movement
        playerBody.Rotate(Vector3.up * xRot);
    }
}
