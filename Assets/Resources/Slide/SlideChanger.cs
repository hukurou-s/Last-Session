using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SlideChanger : MonoBehaviour {

	public GameObject targetScreen;
	private List<string> slideList = new List<string>();
	private Material currentSlide;

	// Use this for initialization
	void Start () {
		GetTextureList (slideList, "Assets/Resources/Slide/");
		//currentSlide.SetTexture ("_BumpMap", slideList [0]);
		foreach (string path in slideList) 
		{
			Debug.Log (path);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetTextureList(List<string> slideList, string filepath)
	{

		string[] files = Directory.GetFiles(filepath, "*.jpg" );
		foreach (var file in files)
		{
			slideList.Add(file);
		}
			
	}
}
