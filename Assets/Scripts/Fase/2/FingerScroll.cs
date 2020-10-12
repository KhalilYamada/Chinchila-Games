using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerScroll : MonoBehaviour
{
	public GameObject[] targetObject;

	public float deccelSpeed;

	private float speed;
	private float oldTouchPosition;
	private bool manualMove;


	public bool outOfBounds;
	public Transform whereToGoBack;

	private void Update()
	{
		for (int i = 0; i < targetObject.Length; i++)
		{
			if (!manualMove)
			{
				if (!outOfBounds)
				{
					speed = Mathf.Lerp(speed, 0, deccelSpeed);
				}
				else
				{
					speed = Vector3.Distance(targetObject[i].transform.position, whereToGoBack.position) * Mathf.Clamp(targetObject[i].transform.position.y - whereToGoBack.position.y, -5, 5);
				}
			}

			if (targetObject[i].activeSelf)
			{
				targetObject[i].transform.localPosition -= new Vector3(0, speed, 0);
			}
			else
			{
				targetObject[i].transform.localPosition = new Vector3(0, 0, 0);
			}
		}
	}

	private void OnMouseDown()
	{
		oldTouchPosition = Input.mousePosition.y;
		manualMove = true;
	}
	private void OnMouseDrag()
	{
		speed = oldTouchPosition - Input.mousePosition.y;
		oldTouchPosition -= speed;
	}
	private void OnMouseUp()
	{
		manualMove = false;
	}

}
