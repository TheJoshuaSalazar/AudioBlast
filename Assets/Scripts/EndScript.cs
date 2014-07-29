using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour
{
    public Texture texture;
    GUIStyle style;

	// Use this for initialization
	void Start () 
    {
        style = new GUIStyle();
        style.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 125, 
            Screen.height / 2, 300, 300), texture, style))
            Application.LoadLevel(0);
    }
}
