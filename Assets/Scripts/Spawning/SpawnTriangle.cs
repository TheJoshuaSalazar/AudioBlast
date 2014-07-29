using UnityEngine;
using System.Collections;

public class SpawnTriangle : MonoBehaviour
{
    public Transform enemyPrefab;
    int maxEnemies;
    int timePassed;
    public InputAudio audioInput;
    public AreaBounds areaBounds;
    public Vibrations vibrations;

    private int totalEnemies;

    // Use this for initialization
    void Start()
    {
        maxEnemies = 1;
        totalEnemies = maxEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioInput.runGame)
            constainSpawn();
    }

    void Spawn()
    {
        //Goes to random spawn point
        Vector3 pos = new Vector3(Random.Range(areaBounds.minX, areaBounds.maxX),
            Random.Range(areaBounds.minY, areaBounds.maxY),
            Random.Range(areaBounds.minZ, areaBounds.maxZ));

        Quaternion rot = new Quaternion(90, 0, 90, 180);

        //create the new enemy facing the player
        Instantiate(enemyPrefab, pos, rot);

        //child it to enemies 
        //enemies = transform;
        totalEnemies--;
    }

    void constainSpawn()
    {
        if (vibrations.averageVibrations > 5.5f &&
            vibrations.averageVibrations < 6.0f)
        {
            totalEnemies = maxEnemies;
            Spawn();
        }
    }
}
