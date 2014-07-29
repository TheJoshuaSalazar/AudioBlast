using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour 
{
    public Frequency freq;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        transform.position = new Vector3(freq.curValues[0], 0.13f, -8.7f);
	}


}
