using UnityEngine;
using System.Collections;

public class DebugStuff : MonoBehaviour {

	public bool overcam = false;

	public GameObject mainCam;
	public GameObject overCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.Find("Main Camera");
		overCam = GameObject.Find("OverCam");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.O) && !overcam){
			overcam = true;
			Debug.Log("Enable Overcam");
			mainCam.GetComponent<Camera>().enabled = false;
			overCam.GetComponent<Camera>().enabled = true;
		}

		if (Input.GetKeyDown(KeyCode.P) && overcam){
			overcam = false;
			Debug.Log("Disable Overcam");
			mainCam.GetComponent<Camera>().enabled = true;
			overCam.GetComponent<Camera>().enabled = false;
		}

		if (Input.GetKeyDown(KeyCode.F1)){
			Debug.Log("Load Stage 1");
			Application.LoadLevel("ScnStage1");
		}

		if (Input.GetKeyDown(KeyCode.F2)){
			Debug.Log("Load Stage 2");
			Application.LoadLevel("ScnStage2");
		}
	}

}
















