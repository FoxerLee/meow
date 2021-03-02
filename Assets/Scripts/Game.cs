using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public Text scoreOnScreen;
    public Text efficiencyOnScreen;
    public AudioSource meow;
    public AudioSource spank;
    

    public double[] treasureCosts;
    public double[] gain;

    private double score = 0;
    private double clickEff = 1;
    // private double efficiency = 0;
    
    private double[] costs;
    private double[] prop;
    private int[] amounts;
    private double treasureProp;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
        // Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        InvokeRepeating("GainEveryOneSecond", 0.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScreen();

    }




    public void BuyItem(int buttonId)
    {
        if (score >= costs[buttonId])
        {
            score -= costs[buttonId];
            amounts[buttonId] += 1;
            costs[buttonId] += costs[buttonId] * prop[buttonId];

            // play sound
            meow.Play();
        }

    }

    public void BuyTreasure(int buttonId)
    {
        if (score >= treasureCosts[buttonId])
        {
            score -= treasureCosts[buttonId];
            treasureCosts[buttonId] += treasureProp * treasureCosts[buttonId];

            if (buttonId % 2 == 0)
            {
                gain[(int)Math.Floor(buttonId/2.0)] *= 2;
            }
            else
            {
                costs[(int)Math.Floor(buttonId/2.0)] /= 2;
            }

        }
    }


    public void ClickCat()
    {
        score += clickEff;

        // play sound
        spank.Play();
    }


    private void UpdateScreen()
    {
        // update score
        scoreOnScreen.text = score.ToString("#0.00") + " meow";
        // update current item number
        Text text;
        for (int i = 0; i < amounts.Count(); i++)
        {
            text = GameObject.Find("factory_btn" + i.ToString() + "/Number").GetComponent<Text>();
            text.text = amounts[i].ToString();
        }
        
        // update current price
        for (int i = 0; i < amounts.Count(); i++)
        {
            text = GameObject.Find("factory_btn" + i.ToString() + "/Price").GetComponent<Text>();
            text.text = costs[i].ToString("#0.00");
        }

        // update efficiency
        double efficiency = 0;
        for (int i = 0; i < amounts.Count(); i++)
        {
            efficiency += gain[i]*amounts[i];
        }
        efficiencyOnScreen.text = efficiency.ToString("#0.00") + " per sec";

        // check if item can be afford
        for (int i = 0; i < amounts.Count(); i++)
        {
            if (costs[i] <= score)
            {
                GameObject.Find("factory_btn" + i.ToString()).GetComponent<Button>().interactable = true;
            }
            else
            {
                GameObject.Find("factory_btn" + i.ToString()).GetComponent<Button>().interactable = false;
            }
        }

        // check if treasure can be afford
        for (int i = 0; i < treasureCosts.Count(); i++)
        {
            if (treasureCosts[i] <= score)
            {
                GameObject.Find("boost_btn" + i.ToString()).GetComponent<Button>().interactable = true;
            }
            else
            {
                GameObject.Find("boost_btn" + i.ToString()).GetComponent<Button>().interactable = false;
            }

        }

    }

    private void GainEveryOneSecond()
    {

        for (int i=0; i<amounts.Count(); i++)
        {
            score += gain[i]*amounts[i];
        }
        // Debug.Log(score);
    }

    private void Restart()
    {
        score = 0;
        // efficiency = 0;
        gain = new double[] {1, 5, 10, 80, 250};
        costs = new double[] {10, 100, 1100, 11000, 35000};
        prop = new double[] {0.1, 0.1, 0.1, 0.1, 0.1};
        // amounts = new int[] {1, 1, 1, 1, 1};
        amounts = new int[] {1, 1, 1, 0, 0};
        treasureCosts = new double[] {100, 200, 2000, 4000, 5000, 10000, 20000, 30000, 50000, 70000};
        treasureProp = 5.0;

    }
}
