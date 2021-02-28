using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Change : MonoBehaviour
{
    private Button this_btn;
    public Image deco;

    // Start is called before the first frame update
    void Start()
    {
        this_btn = this.GetComponent<Button>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!this_btn.interactable)
        {
            deco.color = new Color(1, 1, 1, 0.5f);
        }
        else {
            deco.color = new Color(1, 1, 1, 1);
        }   
    }
}
