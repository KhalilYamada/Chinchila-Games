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

	private ScreenManager screenManager;

    private void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
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

	private void Update()
	{
		if (Keyboard.transform.parent.localPosition.y < -60)
			Keyboard.transform.parent.gameObject.SetActive(isAppearing);

		Keyboard.transform.parent.localPosition = Vector3.Lerp(Keyboard.transform.parent.localPosition, isAppearing ? originalPosition : modifiedPosition, speedToMove);

	}


}
