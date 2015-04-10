using UnityEngine;
using System.Collections;

public class BombEx : MonoBehaviour {
	
	
	public bool silentBombEnabledEx = false;
	public float bombFuse = 3f;
	public int expArea = 4;
	public GameObject spawnExplosion;
	public GameObject spawnSilentExplosion;

	public int[] nClear = { 0, 1, 1, 1, 1, 1};
	public int nPower = 0;
	
	public int[] eClear = { 0, 1, 1, 1, 1, 1};
	public int ePower = 0;
	
	public int[] sClear = { 0, 1, 1, 1, 1, 1};
	public int sPower = 0;
	
	public int[] wClear = { 0, 1, 1, 1, 1, 1};
	public int wPower = 0;
	
	public bool nBonus = false;
	public bool eBonus = false;
	public bool sBonus = false;
	public bool wBonus = false;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3(0, 0, 0);

		StartCoroutine("DetermineBlast");

		StartCoroutine("BombTimer");
		spawnExplosion = Resources.Load<GameObject>("Prefabs/Explosion");
		spawnSilentExplosion = Resources.Load<GameObject>("Prefabs/SilentExplosion");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator DetermineBlast (){
		nPower = 0;
		ePower = 0;
		sPower = 0;
		wPower = 0;
		nBonus = false;
		eBonus = false;
		wBonus = false;
		sBonus = false;
		
		yield return new WaitForSeconds (0.5f);
		
		for (int i = 1; i <= 5; i++){
			if (nClear[i] == 0){
				break;
			}
			nPower++;
		}
		for (int i = 1; i <= 5; i++){
			if (eClear[i] == 0){
				break;
			}
			ePower++;
		}
		for (int i = 1; i <= 5; i++){
			if (sClear[i] == 0){
				break;
			}
			sPower++;
		}
		for (int i = 1; i <= 5; i++){
			if (wClear[i] == 0){
				break;
			}
			wPower++;
		}
		
		if (nBonus){
			nPower++;
		}
		if (eBonus){
			ePower++;
		}
		if (sBonus){
			sPower++;
		}
		if (wBonus){
			wPower++;
		}
	}

	IEnumerator BombTimer (){
		
		yield return new WaitForSeconds(bombFuse);
		GameObject.Find("Player").GetComponent<SpawnBomb>().amount--;
		GameObject.Destroy(this.gameObject);

		if(silentBombEnabledEx == false){ 	//if (!silBombEnaled)
			
			
			//
			for(int i = 0; i < nPower; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z + 1 + i), transform.rotation);
			}
			
			for(int i = 0; i < ePower; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x + 1 + i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			for(int i = 0; i < sPower; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z - 1 - i), transform.rotation);
			}
			
			for(int i = 0; i < wPower; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x - 1 - i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z), transform.rotation);
			
		}
		
		else if(silentBombEnabledEx == true){
			
			
			//
			for(int i = 0; i < nPower; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z + 1 + i), transform.rotation);
			}
			
			for(int i = 0; i < ePower; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x + 1 + i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			for(int i = 0; i < sPower; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z - 1 - i), transform.rotation);
			}
			
			for(int i = 0; i < wPower; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x - 1 - i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z), transform.rotation);
			
		}

	}
	
	
	
}
