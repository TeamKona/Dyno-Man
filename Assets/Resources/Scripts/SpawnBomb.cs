using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {

	bool canBomb = true;
	public GameObject bomb;
	public int amount = 0;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)){
			
			SpawnBomber();

		}

	}

	void SpawnBomber()
	{
		if (amount <= 3 && canBomb)
		{

			Instantiate(bomb,transform.position, transform.rotation);
			amount++;
			canBomb = false;
			StartCoroutine("BombCooldown");

		}
		else if (amount > 3)
		{
			Debug.Log("Too many bombs");
		}
	}
	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - 300, Screen.width / 2 - 400, 50, 30), amount.ToString());
	}


	IEnumerator BombCooldown (){

		yield return new WaitForSeconds(0.75f);
		canBomb = true;
	}
	

}
