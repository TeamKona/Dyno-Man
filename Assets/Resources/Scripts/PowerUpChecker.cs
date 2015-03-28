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
			GameObject.Find("Player").GetComponent<SpawnBomb>().maxAmt = 5;
		}

		if(col.gameObject.name == "SilentBomb")
		{
			bomb.GetComponent<Bomb>().silBombEnabled = true;
			bomb.GetComponent<BombEx>().silentBombEnabledEx = true;
		}
	}
}
