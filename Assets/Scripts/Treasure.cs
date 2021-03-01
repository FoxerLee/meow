using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{

    // public GameObject treasureButton;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseOn(GameObject button)
    {
        text = button.GetComponentInChildren<Text>();
        //If your mouse hovers over the GameObject with the script attached, output this message
        // Debug.Log("Mouse is over GameObject.");
        Debug.Log(button.name == "boost_btn0");
        text.enabled = true;
    }

    public void WhenMouseExit(GameObject button)
    {
        text = button.GetComponentInChildren<Text>();
        text.enabled = false;
    }

}
