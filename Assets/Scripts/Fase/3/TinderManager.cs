using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinderManager : MonoBehaviour
{
	public GameObject TinderUnitPrefab;
	public TMP_Text topText;

	public string[] texto;
	public string[] resposta;

	public static int index;


	private void Start()
	{
		index = 0;
		for (int i = texto.Length-1; i >= 0; i--)
		{
			Instantiate<GameObject>(TinderUnitPrefab, transform).SendMessage("ChangeText", resposta[i]);
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
			topText.text = "acabooou krai";
		}
	}
}
