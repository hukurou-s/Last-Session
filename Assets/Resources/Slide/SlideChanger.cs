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
		slideTexture = Resources.Load<Texture2D>(slideList [currentSlideNum]);
		currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
		targetScreen.GetComponent<Renderer>().material = currentSlideMaterial;
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

			slideTexture = Resources.Load<Texture2D> (slideList [currentSlideNum]);
			currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
			targetScreen.GetComponent<Renderer> ().material = currentSlideMaterial;
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow)) 
		{
			currentSlideNum--;
			if (currentSlideNum < 0) 
			{
				currentSlideNum = 0;
			}
			slideTexture = Resources.Load<Texture2D> (slideList [currentSlideNum]);
			currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
			targetScreen.GetComponent<Renderer> ().material = currentSlideMaterial;
		}

		if (Input.GetKeyUp(KeyCode.UpArrow)) 
		{
			slideTexture = Resources.Load<Texture2D> ("Slide/sub/maru");
			currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
			targetScreen.GetComponent<Renderer> ().material = currentSlideMaterial;
		}

		if (Input.GetKeyUp(KeyCode.DownArrow)) 
		{
			slideTexture = Resources.Load<Texture2D> ("Slide/sub/batu");
			currentSlideMaterial.SetTexture ("_MainTex", slideTexture);
			targetScreen.GetComponent<Renderer> ().material = currentSlideMaterial;
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
}
