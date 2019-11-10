using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public WallScript wall;

    void Start()
    {
        wall.isUp = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name != "Plane")
        {
            Debug.Log("collided");
            wall.SetMoveDown();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Plane" && other.gameObject.tag == "Player")
        {
            Debug.Log("collided");
            wall.SetMoveDown();
            Destroy(this.gameObject);
        }
    }
}
