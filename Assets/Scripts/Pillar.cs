using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float bottom = -.5f;
    public float top = .5f;

    private IEnumerator movement;

    public void SetMoveUp() {
        if (movement != null) {
            StopCoroutine(movement);
        }
        movement = MoveUp();
        StartCoroutine(movement);
    }

    public void SetMoveDown() {
        if (movement != null) {
            StopCoroutine(movement);
        }
        movement = MoveDown();
        StartCoroutine(movement);
    }

    public IEnumerator MoveUp() {
        while (transform.position.y < top) {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, null);
            if (transform.position.y > top) {
                transform.position = new Vector3(transform.position.x, top, transform.position.z);
            }
            yield return new WaitForEndOfFrame();
        }
    }

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
