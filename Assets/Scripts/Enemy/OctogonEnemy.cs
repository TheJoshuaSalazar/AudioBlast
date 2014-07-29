using UnityEngine;
using System.Collections;

public class OctogonEnemy : MonoBehaviour
{
    public Vibrations vibrations;
    public InputAudio audioInput;
    public GameObject bullet;
    public OctagonCollision collision;

    float force = 20;
    Vector3[] directions;
    GameObject[] bulletClip = new GameObject[12];
    int nextBullet = 0;

    // Use this for initialization
    void Start()
    {
        //gameObject.renderer.enabled = false;

        Vector3 shotDirectionUp = Vector3.up;
        Vector3 shotDirectionDown = Vector3.down;
        Vector3 shotDirectionLeft = Vector3.left;
        Vector3 shotDirectionRight = Vector3.right;

        directions = new Vector3[] { shotDirectionDown, shotDirectionLeft, 
                                    shotDirectionRight, shotDirectionUp };

        for (int i = 0; i < bulletClip.Length; i++)
        {
            bulletClip[i] = (GameObject)Instantiate(bullet);
            bulletClip[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioInput.runGame)
        {

            if (vibrations.averageVibrations > 1f && vibrations.averageVibrations < 1.5)
                Shooting();

            if (collision.destroyed)
            {
                foreach (GameObject item in bulletClip)
                {
                    Destroy(item);
                }
                Destroy(this.gameObject);
            }
        }
    }

    void Shooting()
    {
        for (int i = 0; i < directions.Length; i++)
        {
            GameObject go = bulletClip[nextBullet++];

            if (nextBullet >= bulletClip.Length)
                nextBullet = 0;

            go.SetActive(true);
            go.rigidbody.velocity = Vector3.zero;
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.rigidbody.AddForce(new Vector3(directions[i].x, directions[i].y, 0) *
                force);
        }
    }
}
