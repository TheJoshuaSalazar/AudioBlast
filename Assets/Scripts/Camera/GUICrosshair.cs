using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour 
{
    public Texture2D crossHair;
    public InputAudio inputAudio;
    Rect position;

	// Use this for initialization
	void Start () 
    {
        position = new Rect((Screen.width - crossHair.width) / 2, (Screen.height -
        crossHair.height) / 2, crossHair.width, crossHair.height);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        if(inputAudio.runGame)
            GUI.DrawTexture(position, crossHair);
    }
}
