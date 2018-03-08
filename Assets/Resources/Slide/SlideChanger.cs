using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SlideChanger : MonoBehaviour {

	public GameObject targetScreen;
	private List<string> slideList = new List<string>();
	private Texture2D slideTexture;
	public Material currentSlideMaterial;
	private int currentSlideNum = 0;
	private int slideNum = 0;

	// Use this for initialization
	void Start () {
		GetTexturePathList (slideList, "Assets/Resources/Slide/");
		slideNum = slideList.Count;
		ChangeScreenSlide(slideList [currentSlideNum]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.RightArrow)) 
		{
			currentSlideNum++;
			if (currentSlideNum > slideNum-1) 
			{
				currentSlideNum = slideNum-1;
			}
			ChangeScreenSlide(slideList [currentSlideNum]);
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow)) 
		{
			currentSlideNum--;
			if (currentSlideNum < 0) 
			{
				currentSlideNum = 0;
			}
			ChangeScreenSlide(slideList [currentSlideNum]);
		}

		if (Input.GetKeyUp(KeyCode.UpArrow)) 
		{
			ChangeScreenSlide("Slide/sub/maru");
		}

		if (Input.GetKeyUp(KeyCode.DownArrow)) 
		{
			ChangeScreenSlide("Slide/sub/batu");
		}
	}

	public void GetTexturePathList(List<string> slideList, string filepath)
	{

		string[] files = Directory.GetFiles(filepath, "*.jpg" );
		string baseName = "";
		foreach (string file in files)
		{
			baseName = Path.GetFileNameWithoutExtension (file);
			slideList.Add("Slide/" + baseName);
		}
		slideList.Sort ();
	}

	public void ChangeScreenSlide(string filepath) 
	{
		slideTexture = Resources.Load<Texture2D> (filepath);
		currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
		targetScreen.GetComponent<Renderer> ().material = currentSlideMaterial;
	}
}
