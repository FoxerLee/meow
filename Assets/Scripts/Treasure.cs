using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{

    // public GameObject treasureButton;
    public Game GameController;
    public GameObject desc;
    public GameObject itemDesc;
    public Text text;
    public Text itemText;
    public Canvas myCanvas;
    public Vector3 offset;
    public Vector3 itemOffset;
    // Start is called before the first frame update

    private string[] msg = new string[] {"Wheat Grass is twice efficient", "Wheat Grass is half cost", 
                                        "Tuna Snack is twice efficient", "Tuna Snack is half cost", 
                                        "Yummy Can is twice efficient", "Yummy Can is half cost", 
                                        "Little fish toy is twice efficient", "Little fish toy is half cost", 
                                        "Luxury Home is twice efficient", "Luxury Home is half cost", };

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseOn(int msgId)
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        // Debug.Log("Mouse is over GameObject.");
        desc.SetActive(true);

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition + offset, myCanvas.worldCamera, out pos);
        desc.transform.position = myCanvas.transform.TransformPoint(pos);
        
        text.text = msg[msgId] + "\r\n" + GameController.treasureCosts[msgId].ToString() + " meow";
    }

    public void WhenMouseExit()
    {
        desc.SetActive(false);
    }


    public void ShowItemDesc(int msgId)
    {
        itemDesc.SetActive(true);

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition + itemOffset, myCanvas.worldCamera, out pos);
        itemDesc.transform.position = myCanvas.transform.TransformPoint(pos);
        
        itemText.text = "per efficiency: " + GameController.gain[msgId].ToString() + " meow";
    }

    public void HideItemDesc()
    {
        itemDesc.SetActive(false);
    }

}
