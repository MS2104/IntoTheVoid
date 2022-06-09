using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMan : MonoBehaviour
{
	GameObject[] pauseObjects;
	public GameObject pausetext;
	public GameObject play;
	public GameObject restart;
	public GameObject main;
	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				hidePaused();
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
	}


    //Reloads the Level
    
    public void Reload()
	{
		SceneManager.LoadScene("Samplescene");
	
	}

	//controls the pausing of the scene
	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		pausetext.SetActive(true);
		play.SetActive(true);
		main.SetActive(true);
		restart.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		//hide game
		Time.timeScale = 1;
		pausetext.SetActive(false);
		play.SetActive(false);
		main.SetActive(false);
		restart.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    //loads inputted level
    
    public void LoadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}
}
