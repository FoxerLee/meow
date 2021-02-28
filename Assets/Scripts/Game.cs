using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public double score = 0;


    private double[] gain = new double[] {1, 5, 10};
    private double[] costs = new double[] {10, 100, 1000};
    private double[] prop = new double[] {0.1, 0.1, 0.1};
    private int[] amounts = new int[] {1, 1, 1};
    // Start is called before the first frame update
    void Start()
    {
        // Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        InvokeRepeating("GainEveryOneSecond", 0.0f, 1.0f);
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void click(int buttonId)
    {
        if (score >= costs[buttonId])
        {
            score -= costs[buttonId];
            amounts[buttonId] += 1;
            costs[buttonId] += costs[buttonId] * prop[buttonId];
        }

    }

    private void GainEveryOneSecond()
    {
        for (int i=0; i<amounts.Count(); i++)
        {
            score += gain[i]*amounts[i];
        }

        Debug.Log(score);
    }

    private void Restart()
    {
        score = 0;
        gain = new double[] {1, 5, 10};
        costs = new double[] {1, 10, 100};
        prop = new double[] {0.1, 0.1, 0.1};
        amounts = new int[] {1, 1, 1};


    }
}
