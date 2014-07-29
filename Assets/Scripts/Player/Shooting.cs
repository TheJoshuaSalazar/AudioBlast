using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
    public GameObject Bullet;
    private GameObject[] BulletClip = new GameObject[40];
    private int nextBullet = 0;
    private float forceMag = 100.0f;
    private bool shooting = false;

    public Camera mainCamera;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < BulletClip.Length; i++)
        {
            BulletClip[i] = (GameObject)Instantiate(Bullet);
            BulletClip[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindWithTag("Player").renderer.enabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(transform.parent.position, ray.origin);
            isShooting();

            if (shooting && (int)(Time.time%0.5)==0)
            {
                Vector3 shotDirection = mainCamera.transform.forward;//(ray.origin - transform.parent.position).normalized;
                GameObject go = BulletClip[nextBullet++];
                if (nextBullet >= BulletClip.Length)
                    nextBullet = 0;

                go.SetActive(true);
                go.rigidbody.velocity = Vector3.zero;
                go.transform.position = transform.position;
                go.transform.rotation = mainCamera.transform.rotation;
                go.rigidbody.AddForce(shotDirection * forceMag);
            }
        }
	}

    void isShooting()
    {
        if (Input.GetMouseButtonDown(0))
            shooting = true;
        if(Input.GetMouseButtonUp(0))
            shooting = false;
    }
}
