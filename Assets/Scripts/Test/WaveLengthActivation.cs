using UnityEngine;
using System.Collections;

public class WaveLengthActivation : MonoBehaviour 
{
    public Wavelength wavelength;
    public enum WaveLengthHeight { Low = 0, MidLow = 1, MidHigh = 2, High = 3 }
    public WaveLengthHeight height = WaveLengthHeight.Low;

	// Use this for initialization
	void Start () 
    {
        particleSystem.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        startParticle();
	}

    void startParticle()
    {
        if(height == WaveLengthHeight.Low)
        {
            if (wavelength.waveLengthValue > 0.005 && wavelength.waveLengthValue < 0.01)
                particleSystem.enableEmission = true;
            else
                particleSystem.enableEmission = false;
        }
        if (height == WaveLengthHeight.MidLow)
        {
            if (wavelength.waveLengthValue > 0.025 && wavelength.waveLengthValue < 0.03)
                particleSystem.enableEmission = true;
            else
                particleSystem.enableEmission = false;
        }
        if (height == WaveLengthHeight.MidHigh)
        {
            if (wavelength.waveLengthValue > 0.03 && wavelength.waveLengthValue < 0.05)
                particleSystem.enableEmission = true;
            else
                particleSystem.enableEmission = false;
        }
        if (height == WaveLengthHeight.High)
        {
            if (wavelength.waveLengthValue > 0.05 && wavelength.waveLengthValue < 0.07)
                particleSystem.enableEmission = true;
            else
                particleSystem.enableEmission = false;
        }
    }

}
