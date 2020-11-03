using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardKey : MonoBehaviour
{
	public TMP_Text text;


	private char thisLetter;
	private ScreenManager screenManager;
	private void Start()
	{
		text.text = thisLetter.ToString();
		GetComponent<Button>().onClick.AddListener(delegate { CustomButton_onClick(); });
	}




	void CustomButton_onClick()
	{
		screenManager.AddChar(thisLetter.ToString());
	}

	public void SetupKey(char letter, ScreenManager SM)
	{
		thisLetter = letter;
		screenManager = SM;
	}
}
