using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {



	public float bombFuse = 2f;
	public GameObject spawnExplosion;


	// Use this for initialization
	void Start () {
	
		StartCoroutine("BombTimer");


	}
	
	// Update is called once per frame
	void Update () {
	

	}

	IEnumerator BombTimer (){

		yield return new WaitForSeconds(bombFuse);
		GameObject.Find("Player").GetComponent<SpawnBomb>().amount--;
		GameObject.Destroy(this.gameObject);
		Instantiate(spawnExplosion,transform.position, transform.rotation);

		Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z+1), transform.rotation);
		Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z+2), transform.rotation);

		Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z-1), transform.rotation);
		Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z-2), transform.rotation);

		Instantiate(spawnExplosion,new Vector3 (transform.position.x+1,transform.position.y,transform.position.z), transform.rotation);
		Instantiate(spawnExplosion,new Vector3 (transform.position.x+2,transform.position.y,transform.position.z), transform.rotation);

		Instantiate(spawnExplosion,new Vector3 (transform.position.x-1,transform.position.y,transform.position.z), transform.rotation);
		Instantiate(spawnExplosion,new Vector3 (transform.position.x-2,transform.position.y,transform.position.z), transform.rotation);


	}



}
