using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	public Transform enemyPrefab;
	int maxEnemies = 50;
	public InputAudio audioInput;
    public Vibrations vibrations;
	
	private int totalEnemies = 0;
	private GameObject[] spawnPoints;
	private Transform player;
    int spawnPlace = 0;
    
	
	// Use this for initialization
	void Start ()
	{		
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(audioInput.runGame && totalEnemies <= maxEnemies)
			constainSpawn();
	}
	
	void Spawn()
	{
		//Goes to random spawn point
		Vector3 pos = spawnPoints[spawnPlace].transform.position;
        spawnPlace++;
        if (spawnPlace == 8)
            spawnPlace = 0;

		//find rotation tp look player
		Quaternion rot = Quaternion.LookRotation(player.position - pos, new Vector3());

		//create the new enemy facing the player
		Instantiate(enemyPrefab, pos, rot);

		totalEnemies--;
	}
	
	void constainSpawn()
	{	
		if(vibrations.averageVibrations > 4.75f && vibrations.averageVibrations < 5.0f)
		{
			totalEnemies = maxEnemies;
			Spawn();
		}	
	}
}
