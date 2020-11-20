using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GambiarraPraAcabarFase : MonoBehaviour
{
	private void OnEnable()
	{
		PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
		SceneManager.LoadScene("Menu");
	}
}
