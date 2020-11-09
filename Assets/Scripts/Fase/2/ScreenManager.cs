using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
	public int screenIndex = 0;

	[Header("Total Screens")]
	public GameObject[] screens;
	public GameObject tabs;

	[Header("Text Objects")]
	public GameObject[] buttonsObjects;
	public string[] wordAnswers;
	private List<Button> buttons = new List<Button>();
	private List<GameObject> buttonHighlight = new List<GameObject>();
	[HideInInspector] public List<bool> finishedThisWord = new List<bool>(); //Variável que mostra se cada texto é igual ao texto esperado
	private List<TMP_Text> texts = new List<TMP_Text>();
	private int textIndex;
	private TMP_Text currentText;

    void Start()
    {
		FindButtonObjects();


		for (int i = 0; i < buttonHighlight.Count; i++)
		{
			buttonHighlight[i].SetActive(false);
		}
		textIndex = 0;
	}
	
    void Update()
    {
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
			texts.Add(buttonsObjects[i].GetComponentInChildren<TMP_Text>());
		}
	}

	private void IgnoreFinishedText()
	{
		if (currentText == null) return;
		if (textIndex >= 0 && currentText.text == wordAnswers[textIndex])
		{
			finishedThisWord[textIndex] = true;
			buttonHighlight[textIndex].SetActive(false);
			textIndex = -1;
			currentText = null;
		}
	}

	private void FinishedWords()
	{
		if (!finishedThisWord.Contains(false))
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
			SceneManager.LoadScene("Menu");
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

	public void ChangeTextIndex(int ind)
	{
		DeleteEntireWord();
		textIndex = ind;
		currentText = texts[ind];
		for (int i = 0; i < buttonHighlight.Count; i++)
		{
			buttonHighlight[i].SetActive(false);
		}

		if (textIndex >= 0 && currentText.text != wordAnswers[textIndex])
		{
			buttonHighlight[textIndex].SetActive(true);
		}
	}

	public void AddChar(string character)
	{
		if (currentText == null) return;
		if (currentText.text == "")
		{
			character = character.ToUpper(); //eu quase fiz isso na mão pq n esperava que fosse~ tão fácil, aushauhsuasuhau
		}

		currentText.text += character;
	}

	public void DeleteLastChar()
	{
		if (currentText == null) return;
		currentText.text = currentText.text.Remove(currentText.text.Length - 1);
	}

	public void DeleteEntireWord()
	{
		if (currentText == null) return;
		currentText.text = "";
	}
}
