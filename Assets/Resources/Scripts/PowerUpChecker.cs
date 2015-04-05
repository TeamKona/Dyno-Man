using UnityEngine;
using System.Collections;

public class PowerUpChecker : MonoBehaviour {

	public GameObject bomb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = GameObject.FindWithTag("Player").transform.position;
	}

	void OnTriggerStay(Collider col){
		
		if(col.gameObject.name == "PowerUpBombEx"){

			Debug.Log("Power Up Collected");
			GameObject.Find("Player").GetComponent<SpawnBomb>().canBombEx = true;
		}

		if(col.gameObject.name == "PowerUpBombAmtEx")
		{
			Debug.Log("Power Up Collected");
			GameObject.Find("Player").GetComponent<SpawnBomb>().maxAmt = 5;
		}

		if(col.gameObject.name == "SilentBomb")
		{
			Debug.Log("Power Up Collected");
			bomb.GetComponent<Bomb>().silBombEnabled = true;
		}

		if(col.gameObject.name == "SpeedReduce")
		{
			Debug.Log("Power Down Collected");
			StartCoroutine("SpeedDown");

		}


	}
	
	IEnumerator SpeedDown (){

		GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 150f;
		yield return new WaitForSeconds(5.5f);
		GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 400f;
	}

}
