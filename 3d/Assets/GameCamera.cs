using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
    public Transform trackedObject, trackedObjectZoom, targetCamera;
    Vector3 offset;
    static GameCamera myslf;
    Transform currentTrackedObject;
    void Awake()
    {
        myslf = this;
    }
    // Use this for initialization
    void Start()
    {
        currentTrackedObject = trackedObject;

    }

    // Update is called once per frame
    void Update()
    {
        //	offset = offsetObject.position - trackedObject.position;
        targetCamera.position = Vector3.Lerp(targetCamera.position, currentTrackedObject.position, 0.15f) + offset;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentTrackedObject = trackedObjectZoom;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentTrackedObject = trackedObject;
        }
    }
    float shakeDelay = 0.03f, lastShakeTime = float.MinValue;
}
