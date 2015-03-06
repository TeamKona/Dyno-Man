#pragma strict

var radius : float = 5.0;
var power : float = 10.0;

var explosiveDelay : float = 5.0;

function Start () {

yield WaitForSeconds(explosiveDelay);
var grenadeOrigin : Vector3 = transform.position;
var colliders : Collider[] = Physics.OverlapSphere (grenadeOrigin, radius);

for (var hit : Collider in colliders){

	if (hit.rigidbody)
	{
	
		hit.rigidbody.AddExplosionForce(power, grenadeOrigin, radius);
		Destroy(gameObject);
	
	}

}

}

function Update () {

}