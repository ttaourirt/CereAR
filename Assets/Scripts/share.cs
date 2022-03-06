using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class share : MonoBehaviour
{
	public GameObject Screen2;
	public Button ButtonShare;
	//public GameObject ButtonSubmit;
	

	public void Start()

	{
			//GameObject.Find("ButtonExit").GetComponent<Button>().onClick.AddListener(PostData);
			//GameObject.Find("ButtonShare").GetComponent<Button>().onClick.AddListener(PostData);
			//GameObject.Find("Panel").SetActive(false)AddListener(MyCoroutine);
			ButtonShare.onClick.AddListener(PostData);
			//StartCoroutine(TakeSSAndShare());
			//TakeSSAndShare();
			Debug.Log("coucou1");

	}

	IEnumerator MyCoroutine()
	{

		yield return 0;    //Wait one frame

		StartCoroutine(TakeSSAndShare());
	}

	void PostData() => StartCoroutine(TakeSSAndShare());

	private IEnumerator TakeSSAndShare()
	{
		
		yield return new WaitForEndOfFrame();
		
		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();


		string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		//Debug.Log(filePath);
		//// To avoid memory leaks
		Destroy( ss );
		//new NativeShare().AddFile(filePath).SetSubject("Cerealis").SetText("#cerealis #coloring #AR").Share();
		Screen2.gameObject.SetActive(true);

	}
}
