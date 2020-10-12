using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInFrame : MonoBehaviour
{
	public FingerScroll fingerScroll;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		fingerScroll.outOfBounds = false;
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		Debug.Log("foi");
		fingerScroll.outOfBounds = true;
		fingerScroll.whereToGoBack = transform;
	}
}
