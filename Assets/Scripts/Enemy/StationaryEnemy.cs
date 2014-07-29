using UnityEngine;
using System.Collections;

public class StationaryEnemy : MonoBehaviour
{
    public Material[] materials;
    public Wavelength waveLength;
    public InputAudio audioInput;
	public Scoring scoring;
    public GameObject explosiveParticle;
    //public AudioClip explosionSound;
	
	Object Explosion;
		
	// Use this for initialization
	void Start () 
    {
        gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (audioInput.runGame)
        {
            gameObject.renderer.enabled = true;
			
            if (waveLength.waveLengthValue < 0.015)
			{
				collider.enabled = true;

                renderer.material = materials[1];
			}
            else if (waveLength.waveLengthValue > 0.09)
			{
				collider.enabled = false;
                renderer.material = materials[0];
			}
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
			scoring.gameScore += 10;
            Destroy(this.gameObject);
            //AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            var Explosion = Instantiate(explosiveParticle,
                this.transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(Explosion, 1);
        }
    }
}
