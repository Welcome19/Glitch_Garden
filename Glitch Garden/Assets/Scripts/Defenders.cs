using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {
    private StarDisplay starDisplay;

    public int starCost;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        //called method in StarDisplay script
        starDisplay.AddStars(amount);
    }
	
  
}
