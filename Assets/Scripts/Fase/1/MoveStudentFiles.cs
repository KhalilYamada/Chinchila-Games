using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStudentFiles : MonoBehaviour
{
	
	public float minScale = .3f;
	public float maxScale = 3f;

	private Touch secondTouch;

	private Vector3 oldMousePosition;
	private Vector3 oldSecondTouchPosition;
	private float firstScale;
	private float firstAngle;
	private RectTransform rectTransform;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
	//	firstScale = rectTransform.sizeDelta;
	}
	private void OnMouseDown()
	{
		if (Input.touchCount >= 1)
		{
			oldMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			transform.SetSiblingIndex(transform.parent.childCount - 1);
			theresAnActive = true;
		}

		if (Input.touchCount >= 2)
		{
			manualMove = true;
			secondTouch = Input.GetTouch(1);
			oldSecondTouchPosition = Camera.main.ScreenToWorldPoint(secondTouch.position);
			firstAngle = Mathf.Atan2(secondTouch.position.y - Input.GetTouch(0).position.y, secondTouch.position.x - Input.GetTouch(0).position.x) * 180 / Mathf.PI;
			firstScale = Vector3.Distance(Input.GetTouch(0).position, secondTouch.position);
		}
	}

	private void OnMouseDrag()
	{
		if (Input.touchCount >= 1)
		{
			transform.position += Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - oldMousePosition;
			oldMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		}
		if (Input.touchCount >= 2)
		{
			secondTouch = Input.GetTouch(1);

			//Colocar na escala
			float currentTouchDistance = Vector3.Distance(Input.GetTouch(0).position, secondTouch.position);
			float currentScale = Mathf.Clamp(currentTouchDistance / firstScale, minScale, maxScale);
			transform.localScale = new Vector2(currentScale, currentScale);

			//colocar no ângulo
			float angle  = Mathf.Atan2(secondTouch.position.y - Input.GetTouch(0).position.y, secondTouch.position.x - Input.GetTouch(0).position.x) * 180 / Mathf.PI;
			rectTransform.rotation = Quaternion.Euler(0,0, angle - firstAngle);


			oldSecondTouchPosition = Camera.main.ScreenToWorldPoint(secondTouch.position);
		}
	}
	private static bool theresAnActive;
	private bool manualMove;
	private void OnMouseUp()
	{
		DeactivateBoolWithDelay();
		if (secondTouch.phase == TouchPhase.Ended)
		{
			manualMove = false;
		}
	}

	private void Update()
	{
		if (!manualMove && theresAnActive)
		{
			rectTransform.localScale = Vector2.Lerp(rectTransform.localScale, Vector2.one, 0.5f);
			rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, Quaternion.identity, 0.5f);
		}
	}


	private IEnumerator DeactivateBoolWithDelay()
	{
		yield return new WaitForSeconds(2f);
		theresAnActive = false;
	}
	
	
}
