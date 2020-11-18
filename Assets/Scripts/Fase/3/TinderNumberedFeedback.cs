using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinderNumberedFeedback : MonoBehaviour
{
	public TinderManager tinderManager;

	public Sprite[] sprites;
	private Image thisImage;
	private Sprite[] usefulSprites;


	private void Start()
	{
		thisImage = GetComponent<Image>();

		usefulSprites = new Sprite[tinderManager.unitInfo.Length];
		int index = 0;
		for (int i = 0; i < tinderManager.unitInfo.Length; i++)
		{
			index += i + 1;
		}
		index--;

		for (int i = 0; i < usefulSprites.Length; i++)
		{
			usefulSprites[i] = sprites[index + i];
		}

		thisImage.sprite = usefulSprites[TinderManager.index];
	}

	void Update()
	{
		thisImage.sprite = usefulSprites[TinderManager.index];
	}
}
