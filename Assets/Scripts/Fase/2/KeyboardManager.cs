using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
	public static KeyboardManager instance;

	public GameObject KeyPrefab;
	public GameObject Keyboard;
	public List<GameObject> Key = new List<GameObject>();
	public Sprite[] letters;

	[HideInInspector]public bool isAppearing;
	public float speedToMove;
	private Vector3 originalPosition;
	public Vector3 modifiedPosition;

	[HideInInspector] public string keysToAppear;

	private ScreenManager screenManager;

    private void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		


		screenManager = GetComponent<ScreenManager>();
		
		for (int i = 0; i < letters.Length; i++)
		{
			Key.Add(Instantiate(KeyPrefab, Keyboard.transform));
			KeyboardKey keyboardKey = Key[i].GetComponent<KeyboardKey>();
			keyboardKey.SetupKey(letters[i], screenManager);
		}

		originalPosition = Keyboard.transform.parent.localPosition;
		Keyboard.transform.parent.gameObject.SetActive(false);
	}
	/*
	public void ChangeKeys() // tá dando um ruim colossal aqui
	{
		Debug.Log("ativou função");

		if (letters.Length > 0)
		{
			for (int i = 0; i < letters.Length - 1; i++)
			{
				Debug.Log("começou for");
				//GameObject remove = Key[i].gameObject;
				Destroy(Key[i]);
				Key.Remove(Key[i]);
				
				Debug.Log("removeu um");
			}
		}
		string randomizedKeys = "";
		
		
		while (keysToAppear.Length > 0)
		{
			int ind = Random.Range(0, keysToAppear.Length - 1);
			randomizedKeys += keysToAppear[ind];
			keysToAppear.Remove(ind);
		}
		for (int i = 0; i < randomizedKeys.Length; i++)
		{
			Key.Add(Instantiate(KeyPrefab, Keyboard.transform));
			KeyboardKey keyboardKey = Key[i].GetComponent<KeyboardKey>();
			foreach (Sprite item in letters)
			{
				if (item.name == randomizedKeys[i].ToString())
				{
					keyboardKey.SetupKey(item, screenManager);
					break;
				}
			}

		}
	}*/

	private void Update()
	{
		if (Keyboard.transform.parent.localPosition.y < -60)
			Keyboard.transform.parent.gameObject.SetActive(isAppearing);

		Keyboard.transform.parent.localPosition = Vector3.Lerp(Keyboard.transform.parent.localPosition, isAppearing ? originalPosition : modifiedPosition, speedToMove);

	}


}
