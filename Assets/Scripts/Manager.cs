using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class Manager : MonoBehaviour 
{
    public float windowSize = 1024;
    public Channel channel = Channel.Left;
    public FFTWindow fftWindow = FFTWindow.Hamming;

    public enum Channel
    {
        Left = 0,
        Right = 1,
        Average,
        Min,
        Max
    }

    private float[] spectrumData = null;
    private float[] rawAudioData = null;
    private float[] auxiliaryAudioData = null;

    public AudioSource audioSource = null;

    //private List<AudioDataGroup> dataGroup = new List<AudioDataGroup>();
    //private List<AudioController> audioController = new List<AudioController>();

    //private float maxValue = 0.1f;
    private int frequencyRange = 0;
    private float frequencyResolution = 0;

	// Use this for initialization
	void Start () 
    {
        spectrumData = new float[(int)windowSize];
        rawAudioData = new float[(int)windowSize];
        auxiliaryAudioData = new float[(int)windowSize];

        for (int i = 0; i < (int)windowSize; i++)
        {
            spectrumData[i] = 0.0f;
            rawAudioData[i] = 0.0f;
            auxiliaryAudioData[i] = 0.0f;
        }

        CalculateFrequencyResolution();
	}

    public void CalculateFrequencyResolution()
    {
        if (audioSource.clip != null)
        {
            frequencyRange = audioSource.clip.frequency;
            frequencyResolution = (float)frequencyRange / (float)windowSize;
        }
        else
            frequencyRange = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (channel == Channel.Left || channel == Channel.Right)
        {
            AudioListener.GetSpectrumData(spectrumData, (int)channel, fftWindow);
            AudioListener.GetOutputData(rawAudioData, (int)channel);
        }
        else
        {
            AudioListener.GetSpectrumData(spectrumData, 0, fftWindow);
            AudioListener.GetSpectrumData(auxiliaryAudioData, 1, fftWindow);

            for (int i = 0; i < (int)windowSize; i++)
            {
                if (channel == Channel.Average)
                    spectrumData[i] = (spectrumData[i] + auxiliaryAudioData[i]) * 0.5f;
                else if (channel == Channel.Min)
                    spectrumData[i] = Mathf.Min(spectrumData[i], auxiliaryAudioData[i]);
                else if (channel == Channel.Max)
                    spectrumData[i] = Mathf.Max(spectrumData[i], auxiliaryAudioData[i]);
            }

            audioSource.GetOutputData(rawAudioData, 0);
            audioSource.GetOutputData(auxiliaryAudioData, 1);
            for (int i = 0; i < (int)windowSize; i++)
            {
                if (channel == Channel.Average)
                    rawAudioData[i] = (rawAudioData[i] + auxiliaryAudioData[i]) * 0.5f;
                else if (channel == Channel.Min)
                {
                    if (Mathf.Abs(auxiliaryAudioData[i]) < Mathf.Abs(rawAudioData[i]))
                        rawAudioData[i] = auxiliaryAudioData[i];
                }
                else if (channel == Channel.Max)
                {
                    if (Mathf.Abs(auxiliaryAudioData[i]) > Mathf.Abs(rawAudioData[i]))
                        rawAudioData[i] = auxiliaryAudioData[i];
                }
            }
        }
	}

    public float getFrequencyResolution
    {
        get { return frequencyResolution; }
    }

    public float[] getSpectrumData()
    {
        return spectrumData;
    }

    public float[] getRawAudioData()
    {
        return rawAudioData;
    }
}
