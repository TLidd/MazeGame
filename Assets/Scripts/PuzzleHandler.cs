using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(isPuzzleFinished());
    }

    public bool isPuzzleFinished()
    {
        Button[] buttons = this.GetComponentsInChildren<Button>();
        string[] rightAnswer = {"1", "2", "3", "4", "5", "6", "7", "8", ""};
        for (int i = 0; i < buttons.Length; i++)
        {
            if (String.Compare(buttons[i].transform.Find("Text").GetComponent<Text>().text, rightAnswer[i]) != 0)
            {
                return false;
            }
        }
        return true;
    }
}