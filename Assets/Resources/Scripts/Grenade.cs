using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public float radius = 2.0f;
	public float explosiveDelay = 5.0f;
	// Use this for initialization
	void Start () {
	
		 Vector3 grenadeOrigin = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ExplosionTimer()
	{
		yield return new WaitForSeconds(explosiveDelay);
	}
}
