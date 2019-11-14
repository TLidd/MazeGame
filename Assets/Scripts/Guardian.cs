using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    public int energy = 100;
    public int mode = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            mode = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            mode = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            mode = 3;
        }
    }
}
