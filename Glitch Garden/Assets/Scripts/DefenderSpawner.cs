using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    public Camera myCamera;

    private GameObject Parent;
    private StarDisplay starDisplay;

    void Start()
    {
        Parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!Parent)
        {
            Parent = new GameObject("Defenders");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
        //print(Input.mousePosition);
        //print(SnapToGrid(CalculateWorldPointOnMouseClick()));
        Vector2 rawPos = CalculateWorldPointOnMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defenders>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos,defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    private void SpawnDefender(Vector2 roundedPos,GameObject defender)
    {
        GameObject newDef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        newDef.transform.parent = Parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX,newY);
    }

    Vector2 CalculateWorldPointOnMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
}
