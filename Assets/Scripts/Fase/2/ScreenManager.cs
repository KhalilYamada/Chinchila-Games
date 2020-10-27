using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	public int screenIndex = 0;

	[Header("Total Screens")]
	public GameObject[] screens;
	public GameObject tabs;

	[Header("Main Screen Buttons")]
	public GameObject[] buttonHighlight;
	public bool[] finishedThisWord;


	

    void Start()
    {
		
    }
	
    void Update()
    {
        
    }


	public void ChangeScreens()
	{
		bool isOnMain = screens[0].activeSelf;
		for (int i = 0; i < screens.Length; i++)
		{
			screens[i].SetActive(false);
		}

		if (isOnMain)
		{
			screens[screenIndex + 1].SetActive(true);
			tabs.SetActive(true);
		}
		else
		{
			screens[0].SetActive(true);
			tabs.SetActive(false);
		}
	}

	public void ChangeTab(string direction)
	{
		switch (direction)
		{
			default:
				break;
			case "L":
			case "l":
				screenIndex--;
				break;

			case "R":
			case "r":
				screenIndex++;
				break;
		}
		
		if (screenIndex < 1)
		{
			screenIndex = screens.Length - 1;
		}
		if (screenIndex > screens.Length - 1)
		{
			screenIndex = 1;
		}

		for (int i = 0; i < screens.Length; i++)
		{
			screens[i].SetActive(false);
		}

		screens[screenIndex].SetActive(true);
	}
}
