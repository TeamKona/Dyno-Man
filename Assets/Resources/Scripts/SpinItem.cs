using UnityEngine;
using System.Collections;

public class SpinItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3(270, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back , 200 * Time.deltaTime);
	}
}
