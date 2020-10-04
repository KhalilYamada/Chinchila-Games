using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinderSwipe : MonoBehaviour
{
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	public TMP_Text text;

	private string state;
	private float speed;
	public float limitFingerSpeed;

	private float oldTouchPosition;
	private bool manualMove;


	public bool yes;
	public bool no;

	private void Start()
	{
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}
	private void Update()
	{
		if (manualMove) return;

		if (!yes && !no)
		{
			transform.position = Vector3.Lerp(transform.position, originalPosition, 0.2f);
			transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0.2f);
		}
		else if (yes)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(1000, -90, 0), 0.2f);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -11), 0.2f);
		}
		else if (no)
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

		
	}

	private void OnMouseUp()
	{
		if (Mathf.Abs(speed) > limitFingerSpeed)
		{
			Debug.Log(speed);
			if (transform.position.x > 0 && speed < 0)
			{
				yes = true;
				TinderManager.index++;
			}
			else if (transform.position.x < 0 && speed > 0)
			{
				no = true;
				TinderManager.index++;
			}

		}
		manualMove = false;
	}


	public void ChangeText(string texto)
	{
		text.text = texto; // hmm, esse texto é feito de texto
	}
}
