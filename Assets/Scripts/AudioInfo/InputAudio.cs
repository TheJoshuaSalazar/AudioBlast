using UnityEngine;
using System.Collections;
using System.IO;

public class InputAudio : MonoBehaviour 
{
    public EditorUtilityOpenFilePanel openPanel;
	public bool runGame = false;
	public int timeWhenStarted;
    public WWW reStartSong;
    public float songLength = 10000;
    public Texture openFileTex;
    public Texture playTex;

    float startTime;
    bool sameSong = false;
    bool removeGUI;
    GUIStyle style = new GUIStyle();

	// Use this for initializatison
	void Start () 
    {
        openPanel = new EditorUtilityOpenFilePanel();
		removeGUI = false;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(runGame)
		{
            if (startTime - timeWhenStarted >= songLength && songLength != 0)
                //Application.LoadLevel(1);
            if (sameSong)
                StartCoroutine(WaitToStart());
		}
	}
	
	void OnGUI()
	{
        if (fileBrowser != null)
            fileBrowser.OnGUI();
        else
            OnGUIMain();

		if(!removeGUI)
		{
			if(GUI.Button(new Rect(Screen.width/2 - 250, Screen.height/2 - 50, 200, 200),
                openFileTex, style))
			{
        	    openPanel.Apply();
        	    audio.clip = openPanel.www.audioClip;         
                reStartSong = openPanel.www;
				audio.enabled = false;
			}
		}
		
		if(!removeGUI)
		{		
        	if (GUI.Button(new Rect(Screen.width/2 + 50, Screen.height/2 - 50, 200, 200),
                playTex, style))
        	{
                audio.enabled = true;
                runGame = true;
                removeGUI = true;
                startTime = Time.time;
                timeWhenStarted = (int)Time.timeSinceLevelLoad;

                sameSong = true;
                if (audio.clip == null)
                {
                    reStartSong = new WWW(PlayerPrefs.GetString("Restart"));
                    Debug.Log(reStartSong.url);
                    reStartSong.GetAudioClip(false, false, AudioType.UNKNOWN);
                    audio.clip = reStartSong.audioClip;
                    audio.enabled = false;
                    sameSong = true;
                }
                if(audio.clip != null)
                    songLength = audio.clip.length;
        	}
		}
    }
	
    IEnumerator WaitToStart() 
    {
       yield return new WaitForSeconds(0.2f);
       audio.enabled = true;
       songLength = audio.clip.length;
    }

    protected FileBrowser fileBrowser;
    string textPath;
    public delegate void FinishedCallback(string path);

    public void OnGUIMain()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Text File", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(textPath ?? "None Selected");

        if (GUILayout.Button("...", GUILayout.ExpandWidth(false)))
        {
            fileBrowser = new FileBrowser(
                        new Rect(100, 100, 600, 500),
                        "Choose Text FIle",
                        null
                );
            fileBrowser.SelectionPattern = "*.txt";
        }

        GUILayout.EndHorizontal();
    }

    private void FileSelectedCalback(string path)
    {
        fileBrowser = null;
        textPath = path;
    }
}
