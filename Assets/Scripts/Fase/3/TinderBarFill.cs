using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinderBarFill : MonoBehaviour
{
	public TinderSwipe[] unitInfo;
	private Image image;


	private void Start()
    {
		image = GetComponent<Image>();
    }
	
    private void Update()
    {
		float rightChoices = 0;
		for (int i = unitInfo.Length - 1; i >= 0; i--)
		{
			
			if (unitInfo[i].matched)
			{
				rightChoices++;
			}
		}
			image.fillAmount = Mathf.Lerp(image.fillAmount, rightChoices/unitInfo.Length , 0.2f);
    }
}
