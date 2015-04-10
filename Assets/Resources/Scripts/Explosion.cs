using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public bool soundVol = false;

	public GameObject bombUp;		// item 1
	public GameObject blastUp;		// item 2
	public GameObject soundUp;		// item 3

	public GameObject speedDown;	// item 4
	public GameObject soundDown;	// item 5
	public GameObject blastDown;	// item 6

	public int itemDropChance = 0;
	public int whichDrop = 0;

	// Use this for initialization
	void Start () {

		StartCoroutine("DespawnExplosion");
		gameObject.GetComponent<AudioSource>().volume = 0.25f;



		bombUp = Resources.Load<GameObject>("Prefabs/PowerUpBombAmtEx");
		blastUp = Resources.Load<GameObject>("Prefabs/PowerUpBombEx");
		soundUp = Resources.Load<GameObject>("Prefabs/SoundIncrease");

		speedDown = Resources.Load<GameObject>("Prefabs/SpeedReduce");
		soundDown = Resources.Load<GameObject>("Prefabs/SilentBomb");
		blastDown = Resources.Load<GameObject>("Prefabs/ExplosionReduction");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay (Collider col)
	{

		if(col.gameObject.tag == "Combustible")
		{
			itemDropChance = Random.Range(1, 6);	//1, 2, 3, 4, 5		= 20%

			if (itemDropChance == 1){
				//Spawn an Item
				whichDrop = Random.Range(1, 7);		//1, 2, 3, 4, 5, 6  > we have 6 items

				switch(whichDrop){
				case 1:
					//spawn item 1
					Instantiate(bombUp, col.gameObject.transform.position, transform.rotation);
					break;
				case 2:
					//spawn item 2
					Instantiate(blastUp, col.gameObject.transform.position, transform.rotation);
					break;
				case 3:
					//spawn item 3
					Instantiate(soundUp, col.gameObject.transform.position, transform.rotation);
					break;
				case 4:
					//spawn item 4
					Instantiate(speedDown, col.gameObject.transform.position, transform.rotation);
					break;
				case 5:
					//spawn item 5
					Instantiate(soundDown, col.gameObject.transform.position, transform.rotation);
					break;
				case 6:
					//spawn item 6
					Instantiate(blastDown, col.gameObject.transform.position, transform.rotation);
					break;
				default:
					break;
				}
			}
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerMovement>().alive = false;
			col.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y-50,transform.position.z);
		}
		if(col.gameObject.tag == "Player2")
		{
			col.gameObject.GetComponent<P2Movement>().alive2 = false;
			col.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y-100,transform.position.z);
		}

	}
	


	IEnumerator DespawnExplosion (){

		yield return new WaitForSeconds(1.0f);
		GameObject.Destroy(this.gameObject);
	}
}
