using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TinderSwipe : MonoBehaviour
{
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	[Header("Objetos que serão posicionados e mudados de acordo com estado")]
	public TMP_Text textLeft;
	public GameObject frameLeft;
	public TMP_Text textRight;
	public GameObject frameRight;
	private BoxCollider2D boxCollider;
	[HideInInspector] public TinderUnit unitInfo;
	public Image image;
	public GameObject blockingImage;
	public GameObject positioner;

	private string state;
	private float speed;

	[Header("Velocidade de movimento mínima para contar como swipe")]
	public float limitFingerSpeed;

	private float oldTouchPosition;
	private bool manualMove;

	private bool goingRight;
	private bool goingLeft;
	private bool right;
	private bool left;

	[HideInInspector]
	public int thisIndex;

	[Header("Controle de vitória e condição")]
	public bool isInverted;
	public bool matched;

	private Sprite[] frames;
	private Sprite startingSprite;

	private void Start()
	{
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		boxCollider = GetComponent<BoxCollider2D>();
		//image = GetComponent<Image>();

		isInverted = (Random.Range(0, 2) == 1);

		startingSprite = image.sprite;
		textLeft.text = isInverted ? unitInfo.textRight : unitInfo.textLeft;
		textRight.text = isInverted ? unitInfo.textLeft : unitInfo.textRight;
		image.sprite = unitInfo.sprite;
		goingLeft = false;
		goingRight = false;
		manualMove = false;
		frames = unitInfo.frameSprites.frame;
		animFrameCount = 0;
	}
	private void FixedUpdate()
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

		positioner.transform.position = originalPosition;
		positioner.transform.rotation = Quaternion.identity;

		if (boxCollider.enabled)
		{
			Animation();
			image.SetNativeSize();
		}
		else
		{
			image.sprite = startingSprite;
		}
		blockingImage.SetActive(!boxCollider.enabled);
	}

	private int animFrameCount;
	private float floatFrameCount;
	private void Animation()
	{
		image.sprite = frames[animFrameCount];
		if (animFrameCount >= frames.Length - 1)
		{
			floatFrameCount = 0;
		}
		else
		{
			floatFrameCount += Time.deltaTime;
		}
		animFrameCount = (int)(floatFrameCount * 24);
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
		float deccelForMovement = Mathf.Sign(speed) == Mathf.Sign(transform.localPosition.x) ? 1 : Mathf.Lerp(1,0, Mathf.Abs(transform.localPosition.x/100));
		transform.localPosition -= new Vector3(speed * deccelForMovement, -Mathf.Clamp(transform.position.x, -1, 1) * speed / 10, 0);
		transform.localPosition = new Vector2(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -1, 1));
		transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0, 0, speed * deccelForMovement/60));
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
