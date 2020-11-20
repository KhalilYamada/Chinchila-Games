using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
	public int screenIndex;

	[Header("Total Screens")]
	public GameObject[] screens;
	public GameObject tabs;

	[Header("Text Objects")]
	public GameObject[] buttonsObjects;
	public string[] wordAnswers;
	public string[] decoyLetters;
	private List<Button> buttons = new List<Button>();
	private List<GameObject> buttonHighlight = new List<GameObject>();
	[HideInInspector] public List<bool> finishedThisWord = new List<bool>(); //Variável que mostra se cada texto é igual ao texto esperado
	private List<Image[]> texts = new List<Image[]>();
	private int textIndex;
	private Image[] currentText;
	public Sprite quadrado;

    void Start()
    {
		FindButtonObjects();


		for (int i = 0; i < buttonHighlight.Count; i++)
		{
			//buttonHighlight[i].SetActive(false);
		}
		textIndex = 0;
	}
	
    void Update()
    {
		if (!finishedThisWord.Contains(false))
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
			SceneManager.LoadScene("Menu");
		}
		IgnoreFinishedText();
		FinishedWords();
    }

	private void FindButtonObjects()
	{
		for (int i = 0; i < buttonsObjects.Length; i++)
		{
			buttons.Add(buttonsObjects[i].GetComponent<Button>());
			buttonHighlight.Add(buttonsObjects[i].transform.GetChild(0).GetComponent<Image>().gameObject);
			finishedThisWord.Add(false);
			Image[] tempText = new Image[buttonsObjects[i].transform.childCount];
			
			for (int j = 0; j < buttonsObjects[i].transform.childCount; j++)
			{
				tempText[j] = buttonsObjects[i].transform.GetChild(j).GetComponent<Image>();
			}
			texts.Add(tempText);
		}
	}

	private void IgnoreFinishedText()
	{
		if (currentText == null) return;
		string convertedName = "";
		for (int i = 0; i < currentText.Length; i++)
		{
			convertedName += currentText[i].sprite.name;
		}
		if (textIndex >= 0 && convertedName == wordAnswers[textIndex])
		{
			finishedThisWord[textIndex] = true;
		//	buttonHighlight[textIndex].SetActive(false);
			textIndex = -1;
			currentText = null;
		}
	}

	public GameObject[] textsToAppear;
	private void FinishedWords()
	{
		

		if (!finishedThisWord.Contains(false))
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
			SceneManager.LoadScene("Menu");
		}
		
		textsToAppear[1].SetActive(true);
		for (int i = 0; i < finishedThisWord.Count; i++)
		{
			Debug.Log(finishedThisWord[i]);
			textsToAppear[i + 1].SetActive(finishedThisWord[i]);
		}

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
			screens[screenIndex].SetActive(true);
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

	public void ChangeTextIndex(int ind)
	{
		DeleteEntireWord();
		textIndex = ind;
		currentText = texts[ind];
		for (int i = 0; i < buttonHighlight.Count; i++)
		{
		//	buttonHighlight[i].SetActive(false);
		}
		string convertedName = "";
		for (int i = 0; i < currentText.Length - 1; i++)
		{
			convertedName += currentText[i].sprite.name;
		}
		if (textIndex >= 0 && convertedName != wordAnswers[textIndex])
		{
			buttonHighlight[textIndex].SetActive(true);
		}
		
		KeyboardManager.instance.isAppearing = true;
	}

	public void AddChar(Sprite character)
	{
		if (currentText == null) return;
		int index = currentText.Length + 1;

		for (int i = 0; i < currentText.Length; i++)
		{
			if (currentText[i].sprite.name == "Quadrado")
			{
				index = i;
				break;
			}
		}
		if(index <= currentText.Length - 1)
		{
			currentText[index].sprite = character;
		}
	}

	public void DeleteLastChar()
	{
		if (currentText == null) return;
		int index = -1;
		for (int i = currentText.Length - 1; i >= 0; i--)
		{
			if (currentText[i].sprite.name != "Quadrado")
			{
				index = i;
				break;
			}
		}
		if (index >= 0)
		{
			currentText[index].sprite = quadrado;
		}
	}

	public void DeleteEntireWord()
	{
		if (currentText == null) return;
		for (int i = 0; i < currentText.Length; i++)
		{
			currentText[i].sprite = quadrado;
		}
	}
}
