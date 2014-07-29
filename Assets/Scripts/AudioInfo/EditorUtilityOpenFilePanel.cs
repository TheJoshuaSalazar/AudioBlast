using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Alvas.Audio;

public class EditorUtilityOpenFilePanel 
{
    public WWW www;
    string textPath;
    protected FileBrowser fileBrowser;

    void OnGUI()
    {
        if (fileBrowser != null)
            fileBrowser.OnGUI();
        else
            OnGUIMain();
    }

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
                        "Choose Text FIle", null
                        
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

    public void Apply()
    {
        textPath = EditorUtility.OpenFilePanel(
                "Overwrite with ogg",
                "..\\",
                "");
        if (textPath.Length != 0)
        {
            if(textPath.Contains("mp3"))
			    Convert();

            www = new WWW("file:///" + textPath);

            Debug.Log(www.url);
			www.GetAudioClip(false, false, AudioType.UNKNOWN);
        }
    }

    void Convert()
    {
		FileStream file1 = File.OpenRead(textPath);
        Mp3Reader mp3Reader = new Mp3Reader(file1);
	
        IntPtr originalAudioFormat = mp3Reader.ReadFormat();
        byte[] mp3ReaderData = mp3Reader.ReadData();
        mp3Reader.Close();
	
        IntPtr wavFormat = AudioCompressionManager.GetCompatibleFormat(
			originalAudioFormat,
            AudioCompressionManager.PcmFormatTag);
	
       	AcmConverter acmConverter = new AcmConverter(originalAudioFormat, 
       	    wavFormat, false);
	   	
		string waveFileName = textPath;
		int foundS1 = waveFileName.IndexOf("mp3");
		int foundS2 = foundS1 + 3;
		waveFileName = waveFileName.Remove(foundS1, foundS2 - foundS1);
		waveFileName += "wav";

		FileStream outputFile = File.Create(waveFileName);
		textPath = outputFile.Name;

		WaveWriter waveWriter = new WaveWriter(outputFile, 
       	    AudioCompressionManager.FormatBytes(wavFormat));
	   	
       	byte[] waveData = acmConverter.Convert(mp3ReaderData);
		waveWriter.WriteData(waveData);
       	waveWriter.Close();
    }
}