using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TinderManager : MonoBehaviour
{
	public GameObject TinderUnitPrefab;
	public TMP_Text topText;
	public TMP_Text bottomText;
	public TinderUnit[] unitInfo;
	public TinderBarFill barFill;

	public static int index;


	private void Start()
	{
		index = 0;
		barFill.unitInfo = new TinderSwipe[unitInfo.Length];


		for (int i = unitInfo.Length-1; i >= 0; i--)
		{
			GameObject instance;
			instance = Instantiate<GameObject>(TinderUnitPrefab, transform);
			TinderSwipe swipe = instance.GetComponent<TinderSwipe>();
			swipe.unitInfo = unitInfo[i];
			swipe.thisIndex = i;

			
			barFill.unitInfo.SetValue(swipe, i);
		}
		
		
	}

	private void Update()
	{
		if (index < unitInfo.Length)
		{
			topText.text = unitInfo[index].textMain;
			bottomText.text = unitInfo[index].textCharacterName;
		}
		else
		{
			topText.text = "fim da fase";
			bottomText.text = "";
			barFill.FinishLevel();
		}
	}
}
