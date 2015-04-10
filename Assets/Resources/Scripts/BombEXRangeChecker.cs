using UnityEngine;
using System.Collections;

public class BombEXRangeChecker : MonoBehaviour {

	public BombEx bombScript;
	public bool spotCleared = true;
	public bool bonusRange = false;
	
	// Use this for initialization
	void Start () {
		bombScript = transform.parent.gameObject.GetComponent<BombEx>();
		
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
			case "N4":
				bombScript.nClear[4] = 0;
				break;
			case "N5":
				bombScript.nClear[5] = 0;
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
			case "E4":
				bombScript.eClear[4] = 0;
				break;
			case "E5":
				bombScript.eClear[5] = 0;
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
			case "S4":
				bombScript.sClear[4] = 0;
				break;
			case "S5":
				bombScript.sClear[5] = 0;
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
			case "W4":
				bombScript.wClear[4] = 0;
				break;
			case "W5":
				bombScript.wClear[5] = 0;
				break;
			}
		}
		
		if (bonusRange){
			switch(gameObject.name){
			case "N1":
			case "N2":
			case "N3":
			case "N4":
			case "N5":
				bombScript.nBonus = true;
				break;
			case "E1":
			case "E2":
			case "E3":
			case "E4":
			case "E5":
				bombScript.eBonus = true;
				break;
			case "S1":
			case "S2":
			case "S3":
			case "S4":
			case "S5":
				bombScript.sBonus = true;
				break;
			case "W1":
			case "W2":
			case "W3":
			case "W4":
			case "W5":
				bombScript.wBonus = true;
				break;
			}
		}
	}
}
