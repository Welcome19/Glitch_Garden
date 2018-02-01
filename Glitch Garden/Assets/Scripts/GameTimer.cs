using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds=100f;

    private Slider slider;
    private AudioSource audioSource;
    private bool IsEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("please create an object for win");
        }
    }

    // Update is called once per frame
    void Update () {
        //print(Time.timeSinceLevelLoad);
        slider.value =Time.timeSinceLevelLoad / levelSeconds;
		if(Time.timeSinceLevelLoad>=levelSeconds && !IsEndOfLevel)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            IsEndOfLevel = true;
        }
	}
    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
