using UnityEngine;
using System.Collections;

public class OctagonCollision : MonoBehaviour 
{
    public Scoring scoring;
    public bool destroyed = false;
    public GameObject explosiveParticle;
    //public AudioClip explosionSound;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            scoring.gameScore += 10;
            destroyed = true;
            //AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            var Explosion = Instantiate(explosiveParticle,
                this.transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(Explosion, 1);
        }
    }
}
