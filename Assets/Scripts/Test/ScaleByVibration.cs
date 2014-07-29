using UnityEngine;
using System.Collections;

public class ScaleByVibration : MonoBehaviour 
{
    public Vibrations vibration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.localScale = new Vector3(vibration.averageVibrations/5, 
                            vibration.averageVibrations/5, vibration.averageVibrations/5);
	}
}
