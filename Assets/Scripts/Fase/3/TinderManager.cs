using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinderManager : MonoBehaviour
{
	public GameObject TinderUnitPrefab;
	public TMP_Text topText;

	public TinderUnit[] unitInfo;

	public static int index;


	private void Start()
	{
		index = 0;
		
		for (int i = unitInfo.Length-1; i >= 0; i--)
		{
			GameObject instance;
			instance = Instantiate<GameObject>(TinderUnitPrefab, transform);
			TinderSwipe swipe = instance.GetComponent<TinderSwipe>();
			swipe.textLeft.text =  unitInfo[i].textLeft;
			swipe.textRight.text = unitInfo[i].textRight;
			swipe.thisIndex = i;
		}
		
	}

	private void Update()
	{
		if (index < unitInfo.Length)
		{
			topText.text = unitInfo[index].textMain;
		}
		else
		{
			topText.text = "fim da fase";
		}
	}
}
