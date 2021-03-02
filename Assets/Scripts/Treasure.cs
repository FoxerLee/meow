using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{

    // public GameObject treasureButton;
    public GameObject desc;
    public Text text;
    public Canvas myCanvas;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseOn(string msg)
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        // Debug.Log("Mouse is over GameObject.");
        desc.SetActive(true);

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition + offset, myCanvas.worldCamera, out pos);
        desc.transform.position = myCanvas.transform.TransformPoint(pos);
        
        text.text = msg;
    }

    public void WhenMouseExit()
    {
        desc.SetActive(false);
    }

}
