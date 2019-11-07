using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button aboveButton;
    public Button belowButton;
    public Button leftButton;
    public Button rightButton;

    public void CheckButton()
    {
        Button[] buttons = {aboveButton, belowButton, leftButton, rightButton};
        foreach (Button button in buttons)
        {
            if (button != null && button.transform.GetComponent<Image>().color.a == 0)
            {
//                Debug.Log(button.transform.GetComponent<Image>().color.a);
                SwitchPositions(button);
            }
        }
    }

    private void SwitchPositions(Button button)
    {
//        Debug.Log(button.transform.Find("Text").GetComponent<Text>().text + " Needs to be switched with " +
//                  transform.Find("Text").GetComponent<Text>().text);

        string tempText = button.transform.Find("Text").GetComponent<Text>().text;

        button.transform.Find("Text").GetComponent<Text>().text = transform.Find("Text").GetComponent<Text>().text;
        button.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);

        transform.Find("Text").GetComponent<Text>().text = tempText;
        transform.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}