using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
	public GameObject KeyPrefab;
	public GameObject Keyboard;
	public List<GameObject> Key = new List<GameObject>();
	public char[] letters;

	private ScreenManager screenManager;

    private void Awake()
    {
		screenManager = GetComponent<ScreenManager>();
		for (int i = 0; i < letters.Length; i++)
		{
			Key.Add(Instantiate(KeyPrefab, Keyboard.transform));
			KeyboardKey keyboardKey = Key[i].GetComponent<KeyboardKey>();
			keyboardKey.SetupKey(letters[i], screenManager);
		}
    }


}
