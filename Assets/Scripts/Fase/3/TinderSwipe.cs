using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinderSwipe : MonoBehaviour
{
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	public TMP_Text textLeft;
	public TMP_Text textRight;
	private BoxCollider2D boxCollider;

	private string state;
	private float speed;
	public float limitFingerSpeed;

	private float oldTouchPosition;
	private bool manualMove;

	private bool goingRight;
	private bool goingLeft;

	public bool right;
	public bool left;

	private int thisIndex;

	private void Start()
	{
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		boxCollider = GetComponent<BoxCollider2D>();
	}
	private void Update()
	{
		if (goingLeft)
		{
			textLeft.transform.localPosition = Vector3.Lerp(textLeft.transform.localPosition, new Vector3(100, textLeft.transform.localPosition.y, textLeft.transform.localPosition.z), 0.2f);
		}
		else
		{
			textLeft.transform.localPosition = Vector3.Lerp(textLeft.transform.localPosition, new Vector3(0, textLeft.transform.localPosition.y, textLeft.transform.localPosition.z), 0.2f);
		}
		if (goingRight)
		{
			textRight.transform.localPosition = Vector3.Lerp(textRight.transform.localPosition, new Vector3(-100, textRight.transform.localPosition.y, textRight.transform.localPosition.z), 0.2f);
		}
		else
		{
			textRight.transform.localPosition = Vector3.Lerp(textRight.transform.localPosition, new Vector3(0, textRight.transform.localPosition.y, textRight.transform.localPosition.z), 0.2f);
		}

		if (thisIndex == TinderManager.index)
		{
			boxCollider.enabled = true;
		}

		if (manualMove) return;

		if (!right && !left)
		{
			transform.position = Vector3.Lerp(transform.position, originalPosition, 0.2f);
			transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0.2f);
		}
		else if (right)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(1000, -90, 0), 0.2f);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -11), 0.2f);
		}
		else if (left)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-1000, -90, 0), 0.2f);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 11), 0.2f);
		}


		

	}

	private void OnMouseDown()
	{
		oldTouchPosition = Input.mousePosition.x;
		manualMove = true;
	}

	private void OnMouseDrag()
	{
		speed = oldTouchPosition - Input.mousePosition.x;
		transform.localPosition -= new Vector3(speed, -Mathf.Clamp(transform.position.x, -1, 1) * speed / 10, 0);
		transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0, 0, speed/90));
		oldTouchPosition = Input.mousePosition.x;
		if (transform.position.x > 0)
		{
			goingRight = true;
			goingLeft = false;
		}
		else if (transform.position.x < 0)
		{
			goingLeft = true;
			goingRight = false;
		}

	}

	private void OnMouseUp()
	{
		if (Mathf.Abs(speed) > limitFingerSpeed)
		{
			Debug.Log(speed);
			if (goingRight && speed < 0)
			{
				right = true;
				TinderManager.index++;
			}
			else if (goingLeft && speed > 0)
			{
				left = true;
				TinderManager.index++;
			}

		}
		goingLeft = false;
		goingRight = false;
		manualMove = false;
	}


	public void ChangeLeftText(string texto)
	{
		textLeft.text = texto; // hmm, esse texto é feito de texto
	}
	public void ChangeRightText(string texto)
	{
		textRight.text = texto; // hmm, esse texto é feito de texto
	}
	public void TellIndex(int index)
	{
		thisIndex = index;
	}
}
