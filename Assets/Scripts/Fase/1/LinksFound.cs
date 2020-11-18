using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LinksFound : MonoBehaviour
{
	public int totalLinks;
	[HideInInspector]public int linksAmount;


	public Sprite[] sprites;
	private Image thisImage;
	private Sprite[] usefulSprites;
	
	void Start()
    {
		thisImage = GetComponent<Image>();

		usefulSprites = new Sprite[totalLinks];
		int index = 0;
		for (int i = 0; i < totalLinks; i++)
		{
			index += i + 1;
		}
		index--;

		for (int i = 0; i < usefulSprites.Length; i++)
		{
			usefulSprites[i] = sprites[index + i];
		}

		thisImage.sprite = usefulSprites[linksAmount];
    }
	
    void Update()
    {
		thisImage.sprite = usefulSprites[linksAmount];
		CheckIfFinished();
    }

	public void MoreLinks(GameObject gameobject)
	{
		linksAmount++;
		Destroy(gameobject);
	}

	private void CheckIfFinished()
	{
		if (linksAmount >= totalLinks)
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
			SceneManager.LoadScene("Menu");
		}
	}
}
