using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStudentFiles : MonoBehaviour
{
	
	public float minScale = .3f;
	public float maxScale = 3f;

	private Vector3 oldMousePosition;

	private void OnMouseDown()
	{
		oldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.SetSiblingIndex(transform.parent.childCount - 1);
	}

	private void OnMouseDrag()
	{
		transform.position += Camera.main.ScreenToWorldPoint(Input.mousePosition) - oldMousePosition;
		oldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	
	
	private void SetRotation(float angle)
	{
		transform.Rotate(Vector3.forward, angle);

	}
	
	
}
