using UnityEngine;
using System.Collections;

public class SphereLogic : MonoBehaviour 
{
	public Transform sphere;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerCube.objectHit == true)
		{
			SpawnSphere(Random.Range(-1.4f,1.4f), Random.Range(0.3f,1.6f));
			PlayerCube.objectHit = false;
			sphere.transform.localScale += new Vector3(1,1,0);
		}
	}
	
	void SpawnSphere(float x, float y)
	{
		Instantiate(sphere, new Vector3(x,y,-8.7f), Quaternion.identity);
		 
	}
}
