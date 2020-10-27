using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
	[Header ("Objetos a referenciar")]
	public ScreenManager screenManager;
	public GameObject barAcross;
	[Header("Objetos a multiplicar")]
	public List<GameObject> tabs = new List<GameObject>();
	public List<GameObject> tabsPosition = new List<GameObject>();
	private Image[] image;
	private Vector3[] oldPosition;
	[Header("Stats")]
	public float tabSpeed;
	public float tabSpacing;
	private float tabTrueSpacing;
	public float tabMaxSpacing;

	[HideInInspector] public float tabIndex;
	

	private void Start()
    {
		image = new Image[screenManager.screens.Length];
		oldPosition = new Vector3[screenManager.screens.Length];
		image[0] = tabs[0].GetComponent<Image>();
		oldPosition[0] = tabs[0].transform.position;
		for (int i = 1; i < screenManager.screens.Length-1; i++)
		{

			tabsPosition.Add(Instantiate(tabsPosition[0], tabsPosition[0].transform.parent));
			tabsPosition[i].transform.SetSiblingIndex(0);
			tabs.Add(tabsPosition[i].GetComponentInChildren<Image>().gameObject);
			tabs[i].transform.position = tabsPosition[i].transform.position;
			image[i] = tabs[i].GetComponent<Image>();

			oldPosition[i] = tabs[i].transform.position;
		}
		barAcross.transform.SetSiblingIndex(barAcross.transform.childCount-1);
    }
	

    private void Update()																											//Favor não me perguntar, foi um inferno escrever isso e eu não quero lembrar
    {
		tabIndex = screenManager.screenIndex - 1;

		tabTrueSpacing = (tabSpacing * tabs.Count > tabMaxSpacing) ? tabMaxSpacing / tabs.Count : tabSpacing;
		for (int i = tabs.Count-1; i >= 0; i--)
		{
			image[i].color = Color.Lerp(Color.black, Color.white, -Mathf.Abs(tabIndex - i)/tabs.Count + 1);
			tabsPosition[i].transform.position = tabsPosition[0].transform.position + new Vector3(i*tabTrueSpacing, 0, 0);
			tabs[i].transform.position = Vector3.Lerp(oldPosition[i], tabsPosition[i].transform.position, tabSpeed);

			oldPosition[i] = tabs[i].transform.position;
		}
    }
}
