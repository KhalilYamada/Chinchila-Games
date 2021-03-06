﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TinderUnit")]
public class TinderUnit : ScriptableObject
{
	public string textMain;
	public string textCharacterName;
	public string textRight;
	public string textLeft;

	public Vector3 imagePosition;

	public AnimationSprites frameSprites;

	public Sprite sprite;
   
}
