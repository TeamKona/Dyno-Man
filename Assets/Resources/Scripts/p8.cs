using UnityEngine;
using System.Collections;

public class p8 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	//Deny player movement if detects obstacle
	void OnTriggerStay (Collider other){
		if (other.gameObject.name == "Wall" || other.gameObject.name == "Cube1"){
			GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = false;
		}
	}

	//Allow player movement otherwise
	void OnTriggerExit (Collider other){
		GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = true;
	}

}
