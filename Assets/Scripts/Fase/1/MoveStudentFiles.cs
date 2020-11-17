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
	private Vector2 firstScale;
	private float firstAngle;
	private RectTransform rectTransform;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		firstScale = rectTransform.sizeDelta;
	}
	private void OnMouseDown()
	{
		oldMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		transform.SetSiblingIndex(transform.parent.childCount - 1);

		if (Input.touchCount >= 2)
		{
			manualMove = true;
			secondTouch = Input.GetTouch(1);
			oldSecondTouchPosition = Camera.main.ScreenToWorldPoint(secondTouch.position);
			firstAngle = Mathf.Atan2(secondTouch.position.y - Input.GetTouch(0).position.y, secondTouch.position.x - Input.GetTouch(0).position.x) * 180 / Mathf.PI;
		}
	}

	private void OnMouseDrag()
	{
		transform.position += Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - oldMousePosition;
		oldMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

		if (Input.touchCount >= 2)
		{
			secondTouch = Input.GetTouch(1);

			//Colocar na escala
			float currentTouchDistance = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Camera.main.ScreenToWorldPoint(secondTouch.position));
			rectTransform.sizeDelta += new Vector2(currentTouchDistance, currentTouchDistance);

			//colocar no ângulo
			float angle  = Mathf.Atan2(secondTouch.position.y - Input.GetTouch(0).position.y, secondTouch.position.x - Input.GetTouch(0).position.x) * 180 / Mathf.PI;
			rectTransform.Rotate(new Vector3(0,0, angle - firstAngle));


			oldSecondTouchPosition = Camera.main.ScreenToWorldPoint(secondTouch.position);
		}
	}

	private bool manualMove;
	private void OnMouseUp()
	{
		if (secondTouch.phase == TouchPhase.Ended)
		{
			manualMove = false;
		}
	}

	private void Update()
	{
		if (!manualMove)
		{
			rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, firstScale, 0.5f);
			rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, Quaternion.identity, 0.5f);
		}
	}



	private void SetRotation(float angle)
	{
		transform.Rotate(Vector3.forward, angle);

	}
	
	
}
