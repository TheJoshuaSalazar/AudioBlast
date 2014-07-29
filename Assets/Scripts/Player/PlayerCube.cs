using UnityEngine;
using System.Collections;

public class PlayerCube : MonoBehaviour 
{
	public float speed = 20;
	public static bool objectHit = false;
    public InputAudio audioInput;
    public AreaBounds areaBounds;

    public Camera mainCamera;
 
	// Use this for initialization
	void Start () 
	{
        gameObject.renderer.enabled = false;
        mainCamera.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (audioInput.runGame)
        {
            gameObject.renderer.enabled = true;
            mainCamera.transform.localPosition = Vector3.back * 0.2f;
            mainCamera.transform.LookAt(transform);

            outofbounds();
            UserMoverment();
        }
	}
	
	void UserMoverment()
	{
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime; 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.position -= transform.right * Time.deltaTime; 

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime; 
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.R))
            transform.position += transform.up * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.F))
            transform.position -= transform.up * Time.deltaTime; 
	
        if(Input.GetKey(KeyCode.Escape))
            Application.LoadLevel(0);

        if (Input.GetKey(KeyCode.P))
            collider.enabled = false;
        if (Input.GetKey(KeyCode.L))
            collider.enabled = true;
	}

    void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "Enemy" || 
           collision.gameObject.tag =="EnemyBullet")
        {
            PlayerPrefs.SetString("Restart", audioInput.reStartSong.url);
            PlayerPrefs.SetFloat("SongLength", audioInput.songLength);
            Application.LoadLevel(1);
        }
    }

    void outofbounds()
    {
        Vector3 pos = transform.position;

        if (transform.position.x < areaBounds.minX)
            pos.x = areaBounds.minX;
        if (transform.position.x > areaBounds.maxX)
            pos.x = areaBounds.maxX;

        if (transform.position.y < areaBounds.minY)
            pos.y = areaBounds.minY;
        if (transform.position.y > areaBounds.maxY)
            pos.y = areaBounds.maxY;

        if (transform.position.z < areaBounds.minZ)
            pos.z = areaBounds.minZ;
        if (transform.position.z > areaBounds.maxZ)
            pos.z = areaBounds.maxZ;

        transform.position = pos;
    }
}
