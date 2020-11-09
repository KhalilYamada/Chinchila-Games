using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TinderBarFill : MonoBehaviour
{
	public TinderSwipe[] unitInfo;
	private Image image;

	private	float rightChoices;

	public float percentToFinish;

	private void Start()
    {
		image = GetComponent<Image>();
    }
	
    private void Update()
    {
		rightChoices = 0;
		for (int i = unitInfo.Length - 1; i >= 0; i--)
		{
			
			if (unitInfo[i].matched)
			{
				rightChoices++;
			}
		}
			image.fillAmount = Mathf.Lerp(image.fillAmount, rightChoices/unitInfo.Length , 0.2f);

		FinishLevel();
		
    }

	public void FinishLevel()
	{
		if (rightChoices / unitInfo.Length * 100 > percentToFinish)
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
		}

		SceneManager.LoadScene("Menu");
	}
}
