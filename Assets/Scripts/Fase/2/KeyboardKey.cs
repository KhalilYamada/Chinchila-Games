using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardKey : MonoBehaviour
{

	private Sprite sprite;
	private ScreenManager screenManager;

	private void Start()
	{
		GetComponent<Image>().sprite = sprite;
		GetComponent<Button>().onClick.AddListener(delegate { CustomButton_onClick(); });
	}




	void CustomButton_onClick()
	{
		screenManager.AddChar(sprite);
	}

	public void SetupKey(Sprite letter, ScreenManager SM)
	{
		sprite = letter;
		screenManager = SM;
	}
}
