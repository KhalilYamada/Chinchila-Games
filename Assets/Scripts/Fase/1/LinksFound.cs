using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LinksFound : MonoBehaviour
{
	public int totalLinks;
	[HideInInspector]public int linksAmount;
	
	void Start()
    {
        
    }
	
    void Update()
    {
		CheckIfFinished();
    }

	public void MoreLinks(GameObject gameobject)
	{
		linksAmount++;
		Destroy(gameobject);
	}

	private void CheckIfFinished()
	{
		if (linksAmount >= totalLinks)
		{
			PlayerPrefs.SetInt("Finished " + SceneManager.GetActiveScene().name, 1);
			SceneManager.LoadScene("Menu");
		}
	}
}
