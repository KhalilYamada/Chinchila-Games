using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	public int buttonIndex = 0;

	[Header("Total Screens")]
	public GameObject[] screens;

	[Header("Main Screen Buttons")]
	public GameObject[] buttonHighlight;
	public bool[] finishedThisWord;


	

    void Start()
    {
		for (int i = 0; i < buttonHighlight.Length; i++)
		{
			if (!finishedThisWord[i])
			{
				SetHighlightedWord(i);
				break;
			}
		}
    }
	
    void Update()
    {
        
    }


	public void SetHighlightedWord(int index)
	{
		buttonIndex = index;
		for (int i = 0; i < buttonHighlight.Length; i++)
		{
			buttonHighlight[i].SetActive(false);
		}
		buttonHighlight[buttonIndex].SetActive(true);
	}

	public void ChangeScreens()
	{
		bool isOnMain = screens[0].activeSelf;
		for (int i = 0; i < screens.Length; i++)
		{
			screens[i].SetActive(false);
		}

		screens[isOnMain ? buttonIndex + 1 : 0].SetActive(true); //se estiver na tela principal, vai pra tela correspondente à palavra selecionada, senão, vai pra tela principal

	}
}
