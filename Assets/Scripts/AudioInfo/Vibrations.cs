using UnityEngine;
using System.Collections;

public class Vibrations : MonoBehaviour 
{
    public Frequency freq;
    public float averageVibrations;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        averageVibrations = vibrations(freq.curValues);
	}

    float vibrations(float[] frequencyArray)
    {
        return freq.averageArray(frequencyArray) * Time.deltaTime;
    }
}
