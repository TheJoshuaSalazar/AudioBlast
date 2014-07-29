using UnityEngine;
using System.Collections;

public class Frequency : MonoBehaviour 
{	
	private float[] samples;
    public float[] curValues;
    public float diff;
	
	// Use this for initialization
	void Start () 
	{
		samples = new float[512];
        curValues = new float[12];
	}
	
	// Update is called once per frame
	void Update () 
	{
        getAverageFrequency();
        drawFrequencyLines(curValues);
	}

    void drawFrequencyLines(float[] spectrum)
    {
        for (int i = 1; i < curValues.Length; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2),
                           new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2),
                           Color.cyan);

            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3),
                           new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3),
                           Color.yellow);
        }
    }

    void getAverageFrequency()
    {
        int count = 0;

        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        for (int i = 0; i < curValues.Length; i++)
        {
            float average = 0;

            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[i] * (count + 1);
                count++;
            }

            average /= count;
            diff = Mathf.Clamp(average * 10 - curValues[i], 0, 4);
            curValues[i] = average * 10;
        }
    }

    public float averageArray(float[] array)
    {
        float average = 0;
        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }

        average /= array.Length;
        return average;
    }
}
