using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour 
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15;
    public float sensitivityY = 15;

    public float minimimX = -360;
    public float maximimX = 360;
    public float minimimY = -60;
    public float maximimY = 60;

    public GameObject target;
    public InputAudio inputAudio;

    Vector3 offset;

    float rotationY = 0;

	// Use this for initialization
	void Start () 
    {
        offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (inputAudio.runGame)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y +
                    Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimimY, maximimY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimimY, maximimY);

                transform.localEulerAngles = new Vector3(-rotationY,
                    transform.localEulerAngles.y, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                //float horizontal = Input.GetAxis("Mouse X") * sensitivityX;
                float vertical = Input.GetAxis("Mouse Y") * sensitivityY;
                target.transform.Rotate(vertical, 0, 0);
                
                float desiredAngle = target.transform.eulerAngles.x;
                Quaternion rotation = Quaternion.Euler(desiredAngle, 0, 0);
                transform.position = target.transform.position - (rotation * offset);
                
                transform.LookAt(target.transform);
            }
        }
	}
}
