using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TinderSwipe : MonoBehaviour
{
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	public TMP_Text textLeft;
	public GameObject frameLeft;
	public TMP_Text textRight;
	public GameObject frameRight;
	private BoxCollider2D boxCollider;
	[HideInInspector] public TinderUnit unitInfo;
	private Image image;

	private string state;
	private float speed;
	public float limitFingerSpeed;

	private float oldTouchPosition;
	private bool manualMove;

	private bool goingRight;
	private bool goingLeft;
	private bool right;
	private bool left;

	[HideInInspector]
	public int thisIndex;

	public bool isInverted;
	public bool matched;

	private void Start()
	{
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		boxCollider = GetComponent<BoxCollider2D>();
		image = GetComponent<Image>();

		isInverted = (Random.Range(0, 2) == 1);

		textLeft.text = isInverted ? unitInfo.textRight : unitInfo.textLeft;
		textRight.text = isInverted ? unitInfo.textLeft : unitInfo.textRight;
		image.sprite = unitInfo.sprite;
		goingLeft = false;
		goingRight = false;
		manualMove = false;
	}
	private void Update()
	{
		frameLeft.transform.localPosition = Vector3.Lerp(frameLeft.transform.localPosition, new Vector3(goingLeft ? 0 : 150, frameLeft.transform.localPosition.y, frameLeft.transform.localPosition.z), 0.2f);
		frameRight.transform.localPosition = Vector3.Lerp(frameRight.transform.localPosition, new Vector3(goingRight ? 0 : -150, frameRight.transform.localPosition.y, frameRight.transform.localPosition.z), 0.2f);

		boxCollider.enabled = (thisIndex == TinderManager.index);

		if (!manualMove)
		{
			if (right)
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(1000, -90, 0), 0.2f);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -11), 0.2f);
			}
			else if (left)
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-1000, -90, 0), 0.2f);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 11), 0.2f);
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, originalPosition, 0.2f);
				transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0.2f);
			}
		}
	}

	#region Input Management
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

		matched = isInverted ? left : right;
		goingLeft = false;
		goingRight = false;
		manualMove = false;
	}
	#endregion

}
