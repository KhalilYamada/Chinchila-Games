using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStudentFiles : MonoBehaviour
{
	
	public float minScale = .3f;
	public float maxScale = 3f;

	private Touch firstTouch;
	private Vector3 firstTouchPosition;
	private Vector3 firstTouchOffset;

	private Touch secondTouch;
	private Vector3 secondTouchPosition;

	private float initialDistance;
	private float currentDistance;
	private Vector3 initialScale;

	private Vector3 lastDirection;
	private Vector3 currentDirection;

	private void OnMouseDown()
	{
		HandleTouches();
	}

	private void HandleTouches()
	{
		if (Input.touchCount > 0)
		{
			HandleFirstTouch();
			if (Input.touchCount > 1)
			{
				HandleSecondTouch();
			}
		}
	}

	private void HandleFirstTouch()
	{
		firstTouch = Input.GetTouch(0);
		firstTouchPosition = Camera.main.ScreenToWorldPoint(firstTouch.position);

		switch (firstTouch.phase)
		{
			case TouchPhase.Began:
				transform.position = firstTouchPosition;
				firstTouchOffset = transform.position - firstTouchPosition;
				break;
			case TouchPhase.Moved:
				if (Input.touchCount == 1)
				{
					SetPosition(firstTouchPosition);
				}
				break;
			case TouchPhase.Canceled:
			case TouchPhase.Ended:
				break;
		}

	}

	private void HandleSecondTouch()
	{
		secondTouch = Input.GetTouch(1);
		secondTouchPosition = Camera.main.ScreenToWorldPoint(secondTouch.position);

		if (secondTouch.phase == TouchPhase.Began)
		{
			currentDirection = secondTouchPosition - firstTouchPosition;
			lastDirection = currentDirection;

			currentDistance = (lastDirection).sqrMagnitude;
			initialDistance = currentDistance;

			initialScale = transform.localScale;
		}
		else if (secondTouch.phase == TouchPhase.Moved || firstTouch.phase == TouchPhase.Moved)
		{

			currentDirection = secondTouchPosition - firstTouchPosition;

			float angle = Vector3.Angle(currentDirection, lastDirection);

			Vector3 cross = Vector3.Cross(currentDirection, lastDirection);
			if (cross.z > 0)
			{
				angle = -angle;
			}

			SetRotation(angle);
			lastDirection = currentDirection;

			currentDistance = (currentDirection).sqrMagnitude;
			float difference = currentDistance / initialDistance;
			SetScale(difference);
		}

		if (secondTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Canceled)
		{
			firstTouchOffset = transform.position - firstTouchPosition;
		}

	}

	private void SetPosition(Vector3 position)
	{
		Vector3 newPosition = position + firstTouchOffset;
		newPosition.z = transform.position.z;
		transform.position = newPosition;
	}
	
	private void SetRotation(float angle)
	{
		transform.Rotate(Vector3.forward, angle);

	}
	
	private void SetScale(float percentDifference)
	{
		Vector3 newScale = initialScale * percentDifference;
		if (newScale.x > minScale && newScale.y > minScale && newScale.x < maxScale && newScale.y < maxScale)
		{
			newScale.z = 1f;
			transform.localScale = newScale;
		}

	}
}
