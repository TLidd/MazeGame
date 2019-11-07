using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {
    public bool isUp = false;
    public bool isOuterWall = false;
    public float moveSpeed = .5f;
    public float top = .5f;
    public float bottom = -.475f;

    private IEnumerator movement; //This holds the coroutine to handle the movement for the walls
    private GameObject Guardian; //Reference to the guardian object

    void Start() {
        //Get walls into correct position
        if (isUp) {
            GetComponent<Renderer>().material.color = Color.red;
            movement = MoveUp();
            StartCoroutine(movement);
        } else {
            GetComponent<Renderer>().material.color = Color.green;
            movement = MoveDown();
            StartCoroutine(movement);
        }
        Guardian = GameObject.Find("Guardian");
    }

    void Update() {

    }

    //When wall is clicked on, move wall up or down
    void OnMouseDown() {
        if (!isOuterWall) {
            if (isUp) {
                StopCoroutine(movement);
                movement = MoveDown();
                StartCoroutine(movement);
                isUp = false;
                GetComponent<Renderer>().material.color = Color.green;
            } else if (!isUp) {
                StopCoroutine(movement);
                StopCoroutine(movement);
                movement = MoveUp();
                StartCoroutine(movement);
                isUp = true;
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    //Move wall to top
    public IEnumerator MoveUp() {
        while (transform.position.y < top) {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, null);
            if (transform.position.y > top) {
                transform.position = new Vector3(transform.position.x, top, transform.position.z);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    //Move wall to bottom
    public IEnumerator MoveDown() {
        while (transform.position.y > bottom) {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, null);
            if (transform.position.y < bottom) {
                transform.position = new Vector3(transform.position.x, bottom, transform.position.z);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
