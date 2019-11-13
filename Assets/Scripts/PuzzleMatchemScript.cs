using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMatchemScript : MonoBehaviour
{
    public int symbol;
    public int value;
    public Color colorValue;
    public Color defaultColorValue = Color.grey;
    private void OnMouseDown()
    {
        print("clicked me");
        PuzzleHandler.Instance.SetValue(this);
    }
}
