using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotebookTextWriter : MonoBehaviour
{
	public TMP_Text text;


	public void AddChar(string character)
	{
		text.text += character;
	}

}
