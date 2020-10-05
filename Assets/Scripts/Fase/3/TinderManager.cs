using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinderManager : MonoBehaviour
{
	public GameObject TinderUnitPrefab;
	public TMP_Text topText;

	public string[] texto;
	public string[] respostaLeft;
	public string[] respostaRight;

	public static int index;


	private void Start()
	{
		index = 0;
		
		for (int i = texto.Length-1; i >= 0; i--)
		{
			GameObject instance;
			instance = Instantiate<GameObject>(TinderUnitPrefab, transform);
			instance.SendMessage("ChangeLeftText", respostaLeft[i]);
			instance.SendMessage("ChangeRightText", respostaRight[i]);
			instance.SendMessage("TellIndex", i);
		}
		
	}

	private void Update()
	{
		if (index < texto.Length)
		{
			topText.text = texto[index];
		}
		else
		{
			topText.text = "fim da fase";
		}
	}
}
