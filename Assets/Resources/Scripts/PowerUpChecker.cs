using UnityEngine;
using System.Collections;

public class PowerUpChecker : MonoBehaviour {

	public GameObject bomb;
	public GameObject bombEx;
	public GameObject explosion;
	public GameObject silentexplosion;

	// Use this for initialization
	void Start () {

		bomb = Resources.Load<GameObject>("Prefabs/Bomb");
		bombEx = Resources.Load<GameObject>("Prefabs/BombEx");

		explosion.GetComponent<AudioSource>().maxDistance = 5f;
		explosion.GetComponent<ParticleSystem>().startSize = 0.5f;
		silentexplosion.GetComponent<AudioSource>().maxDistance = 5f;
		silentexplosion.GetComponent<ParticleSystem>().startSize = 0.5f;
		bomb.GetComponent<Bomb>().expAreaNorm = 3;
		bombEx.GetComponent<BombEx>().expArea = 4;
		GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 300f;
		bomb.GetComponent<Bomb>().silBombEnabled = false;
		GameObject.Find("Player").GetComponent<SpawnBomb>().canBombEx = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = GameObject.FindWithTag("Player").transform.position;
	}

	void OnTriggerStay(Collider col){
		
		if(col.gameObject.name == "PowerUpBombEx(Clone)"){

			Debug.Log("Blast Up");
			GameObject.Find("Player").GetComponent<SpawnBomb>().canBombEx = true;
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "PowerUpBombEx"){
			
			Debug.Log("Blast Up");
			GameObject.Find("Player").GetComponent<SpawnBomb>().canBombEx = true;
		}

		if(col.gameObject.name == "PowerUpBombAmtEx(Clone)"){
			Debug.Log("Bomb Up");
			GameObject.Find("Player").GetComponent<SpawnBomb>().maxAmt = 5;
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "PowerUpBombAmtEx"){
			Debug.Log("Bomb Up");
			GameObject.Find("Player").GetComponent<SpawnBomb>().maxAmt = 5;
		}

		if(col.gameObject.name == "SilentBomb(Clone)")
		{
			Debug.Log("Sound Down");
			bomb.GetComponent<Bomb>().silBombEnabled = true;
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "SilentBomb")
		{
			Debug.Log("Sound Down");
			bomb.GetComponent<Bomb>().silBombEnabled = true;
		}

		if(col.gameObject.name == "SpeedReduce(Clone)")
		{
			Debug.Log("Speed Down");
			StartCoroutine("SpeedDown");
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "SpeedReduce")
		{
			Debug.Log("Speed Down");
			StartCoroutine("SpeedDown");
		}

		if(col.gameObject.name == "ExplosionReduction(Clone)")
		{
			Debug.Log("Blast Down");
			StartCoroutine("SmallExplosion");
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "ExplosionReduction")
		{
			Debug.Log("Blast Down");
			StartCoroutine("SmallExplosion");
		}

		if(col.gameObject.name == "SoundIncrease(Clone)")
		{
			Debug.Log("Sound Up");
			StartCoroutine("SoundInc");
			GameObject.Destroy(col.gameObject);
		}
		if(col.gameObject.name == "SoundIncrease")
		{
			Debug.Log("Sound Up");
			StartCoroutine("SoundInc");
		}


	}

	IEnumerator SoundInc (){
		
		explosion.GetComponent<AudioSource>().maxDistance = 100f;
		explosion.GetComponent<ParticleSystem>().startSize = 10f;

		silentexplosion.GetComponent<AudioSource>().maxDistance = 100f;
		silentexplosion.GetComponent<ParticleSystem>().startSize = 10f;

		yield return new WaitForSeconds(25.5f);

		explosion.GetComponent<AudioSource>().maxDistance = 5f;
		explosion.GetComponent<ParticleSystem>().startSize = 0.5f;
		silentexplosion.GetComponent<AudioSource>().maxDistance = 5f;
		silentexplosion.GetComponent<ParticleSystem>().startSize = 0.5f;
	}
	
	IEnumerator SmallExplosion (){
		
		bomb.GetComponent<Bomb>().expAreaNorm = 1;
		
		bombEx.GetComponent<BombEx>().expArea = 1;

		yield return new WaitForSeconds(5.5f);

		bomb.GetComponent<Bomb>().expAreaNorm = 3;
		bombEx.GetComponent<BombEx>().expArea = 4;

	}

	IEnumerator SpeedDown (){

		GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 150f;
		yield return new WaitForSeconds(5.5f);
		GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 400f;
	}

}
