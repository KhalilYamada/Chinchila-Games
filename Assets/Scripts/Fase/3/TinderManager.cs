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
    public static int indexChanged;

    public GameObject[] soundEffect;


	private void Start()
	{
		index = 0;
        indexChanged = index;
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

        Sound();
	}

    public void Sound()
    {
        if (index == 1) soundEffect[0].SetActive(true);
        if (index == 2) soundEffect[1].SetActive(true); 
        if (index == 3) soundEffect[2].SetActive(true); 
        if (index == 4) soundEffect[3].SetActive(true); 
        if (index == 5) soundEffect[4].SetActive(true); 
        if (index == 6) soundEffect[5].SetActive(true); 
        if (index == 7) soundEffect[6].SetActive(true);  
        if (index == 8) soundEffect[7].SetActive(true); 

    }
}
