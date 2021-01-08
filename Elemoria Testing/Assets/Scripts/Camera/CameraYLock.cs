using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYLock : MonoBehaviour
{
    public Camera cam;

    Transform lockCam;
    public float max;
    public float min;

    void Start()
    {
        lockCam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lockCam.position.y > max)
        {
            cam.transform.position = new Vector3 (cam.transform.position.x, max, cam.transform.position.z);
        }
        if(lockCam.position.y < min)
        {
            cam.transform.position = new Vector3 (cam.transform.position.x, min, cam.transform.position.z);
        }
    }
}
