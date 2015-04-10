using UnityEngine;
using System.Collections;

public class BombRangeChecker : MonoBehaviour {

	public Bomb bombScript;
	public bool spotCleared = true;
	public bool bonusRange = false;

	// Use this for initialization
	void Start () {
		bombScript = transform.parent.gameObject.GetComponent<Bomb>();

		StartCoroutine("CheckingTime");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider col) {

		if (col.gameObject.name == "Wall"){
			spotCleared = false;
		}

		if (col.gameObject.name == "Break"){
			spotCleared = false;
			bonusRange = true;
		}
	}

	IEnumerator CheckingTime (){
		yield return new WaitForSeconds(0.1f);

		if (!spotCleared){
			switch(gameObject.name){
			case "N1":
				bombScript.nClear[1] = 0;
				break;
			case "N2":
				bombScript.nClear[2] = 0;
				break;
			case "N3":
				bombScript.nClear[3] = 0;
				break;
			case "E1":
				bombScript.eClear[1] = 0;
				break;
			case "E2":
				bombScript.eClear[2] = 0;
				break;
			case "E3":
				bombScript.eClear[3] = 0;
				break;
			case "S1":
				bombScript.sClear[1] = 0;
				break;
			case "S2":
				bombScript.sClear[2] = 0;
				break;
			case "S3":
				bombScript.sClear[3] = 0;
				break;
			case "W1":
				bombScript.wClear[1] = 0;
				break;
			case "W2":
				bombScript.wClear[2] = 0;
				break;
			case "W3":
				bombScript.wClear[3] = 0;
				break;
			}
		}

		if (bonusRange){
			switch(gameObject.name){
			case "N1":
			case "N2":
			case "N3":
				bombScript.nBonus = true;
				break;
			case "E1":
			case "E2":
			case "E3":
				bombScript.eBonus = true;
				break;
			case "S1":
			case "S2":
			case "S3":
				bombScript.sBonus = true;
				break;
			case "W1":
			case "W2":
			case "W3":
				bombScript.wBonus = true;
				break;
			}
		}
	}
}
