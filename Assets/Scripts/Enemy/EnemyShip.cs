using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour 
{
	Transform target;
	Transform myTransform;
	float moveSpeed = 0.03f;
	float roationSpeed = 0.5f;
    public Frequency freq;
    float startTime;

	public InputAudio audioInput;
    public Scoring score;
    public GameObject explosiveParticle;
    //public AudioClip explosionSound;
	
	void Awake()
	{
		myTransform = transform;	
	}
	
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(audioInput.runGame)
		{
        	moveSpeed = freq.averageArray(freq.curValues)/1000;
			
        	myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
        	    Quaternion.LookRotation(target.position - myTransform.position),
        	    roationSpeed * Time.deltaTime);
			
        	transform.Rotate((Mathf.Sin((Time.time - startTime - 0.4f)*0.5f)*0.9f),
        	    0, 0);
				
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider collision)	
	{
        if (collision.gameObject.tag == "Bullet")
        {
            score.gameScore += 5;
            //AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            //Destroy(this.gameObject);

            var Explosion = Instantiate(explosiveParticle,
                this.transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(Explosion, 1);
        }
	}
}
