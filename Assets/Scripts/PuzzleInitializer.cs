using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInitializer : MonoBehaviour
{
    public GameObject PuzzlePrefab;
    public List<GameObject> CardObjects;

    public int[] Values;

    public float Spacing;
    public int PuzzleSize;

    public Color[] ColorValues;
    // Start is called before the first frame update
    void Start()
    {
        ColorValues = new Color[]{Color.blue, Color.red, Color.yellow, Color.magenta, Color.white, Color.green,
                                  Color.cyan, Color.black};
        CreateObjects();

        Values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
        RandomizeArray(Values.Length - 1);

        SetValues();
        SetColorValues();
    }
    
    void CreateObjects()
    {
        for (int i = 0; i < PuzzleSize; ++i)
        {
            for (int j = 0; j < PuzzleSize; ++j)
            {
                GameObject PuzzlePiece = Instantiate(PuzzlePrefab);
                PuzzlePrefab.transform.position = new Vector3(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y + j, this.gameObject.transform.position.z + i);
                CardObjects.Add(PuzzlePiece);
            }
        }
    }

    void RandomizeArray(int n)
    {
        if (n == 0) return;

        if(n > 0)
        {
            int randomNum = Random.Range(1, 16);
            int temp = Values[n];
            Values[n] = Values[randomNum];
            Values[randomNum] = temp;
        }

        RandomizeArray(--n);
    }

    void SetValues()
    {
        for (int i = 0; i < Values.Length; ++i)
        {
            PuzzleMatchemScript Piece = CardObjects[i].GetComponent<PuzzleMatchemScript>();
            Piece.value = Values[i];
        }
    }

    void SetColorValues()
    {
        foreach(GameObject item in CardObjects)
        {
            item.GetComponent<PuzzleMatchemScript>().colorValue = ColorValues[item.GetComponent<PuzzleMatchemScript>().value-1];
            item.GetComponent<PuzzleMatchemScript>().defaultColorValue = Color.gray;
        }
    }
}

