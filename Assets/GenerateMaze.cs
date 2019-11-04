using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    GameObject cube;
    GameObject[,] CubeArray = new GameObject[20, 20];
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 20; x++)
        {
            for(int z = 0; z < 20; z++)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale += new Vector3(0, 5, 0);
                if(x % 19 == 0 || z % 19 == 0)
                {
                    cube.transform.position = new Vector3(x, 2.5f, z);
                }
                else
                {
                    cube.transform.position = new Vector3(x, -2.5f, z);
                }
                CubeArray[x , z] = cube;
            }
        }
    }
    private class point
    {
        int x, z;
        public point(int x, int z)
        {
            x = x;
            z = z;
        }
    }
}
