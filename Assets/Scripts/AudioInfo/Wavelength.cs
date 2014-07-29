using UnityEngine;
using System.Collections;

public class Wavelength : MonoBehaviour 
{
    public Frequency freq;
    public float waveLengthValue;
    int offset;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        waveLengthValue = wavelength(freq.curValues);
	}

    float wavelength(float[] frequencyArray)
    {
        float d = freq.averageArray(frequencyArray) / Time.deltaTime;
        return (1 / d) * 100;
    }
}
