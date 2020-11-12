using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerScroll : MonoBehaviour
{
	public GameObject[] targetObject;
	private Vector3[] originalPosition;

	public float deccelSpeed;

	private float speed;
	private float oldTouchPosition;
	private bool manualMove;

	[HideInInspector] public bool outOfBounds;
	[HideInInspector] public Transform whereToGoBack;

	private void Start()
	{
		originalPosition = new Vector3[targetObject.Length];
		for (int i = 0; i < targetObject.Length; i++)
		{
			originalPosition[i] = targetObject[i].transform.localPosition;
		}
	}

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
				targetObject[i].transform.position -= new Vector3(0, speed/200, 0);
			}
			else
			{
				targetObject[i].transform.localPosition = originalPosition[i];
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
