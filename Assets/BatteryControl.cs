using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryControl : MonoBehaviour
{
	public Slider battery;
	public Text batteryAmount;
	public Image fill;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        battery.value = 0.49f;
        batteryAmount.text = battery.value * 100f + "%";

        if(battery.value < .15)
        	fill.color = Color.red;
        else if(battery.value < .5)
        	fill.color = Color.yellow;
        else
        	fill.color = Color.green;
    }
}
