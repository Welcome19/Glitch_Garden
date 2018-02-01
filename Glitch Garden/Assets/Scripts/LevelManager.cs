using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter != 0)
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        else
            Debug.Log("auto load disabled");
    }
    public void LoadLevel(string name)
    {
                Application.LoadLevel(name);    
    }
    public void QuitLevel()
    {
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        
        Application.LoadLevel(Application.loadedLevel + 1); 
    }
    
}
