using UnityEngine;
using System.Collections;

public class RemoveBackgoundTexture : MonoBehaviour
{
    public InputAudio inputAudio;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (inputAudio.runGame)
        {
            guiTexture.enabled = false;
        }
	}
}
