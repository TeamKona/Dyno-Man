using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {


	public bool silBombEnabled = false;
	public float bombFuse = 3;
	public int expAreaNorm = 3;
	public GameObject spawnExplosion;
	public GameObject spawnSilentExplosion;

	// Use this for initialization
	void Start () {
	
		StartCoroutine("BombTimer");
		spawnExplosion = Resources.Load<GameObject>("Prefabs/Explosion");
		spawnSilentExplosion = Resources.Load<GameObject>("Prefabs/SilentExplosion");
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.up, 200 * Time.deltaTime);
	}

	IEnumerator BombTimer (){

		yield return new WaitForSeconds(bombFuse);
		GameObject.Find("Player").GetComponent<SpawnBomb>().amount--;
		GameObject.Destroy(this.gameObject);

		if(silBombEnabled == false){ 	//if (!silBombEnaled)

			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z+i), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z-i), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x+i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnExplosion,new Vector3 (transform.position.x-i,transform.position.y,transform.position.z), transform.rotation);
			}

		}

		else if(silBombEnabled == true){

			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z+i), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z-i), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x+i,transform.position.y,transform.position.z), transform.rotation);
			}
			
			for(int i = 0; i < expAreaNorm; i++)
			{
				Instantiate(spawnSilentExplosion,new Vector3 (transform.position.x-i,transform.position.y,transform.position.z), transform.rotation);
			}

		}



	}



}
