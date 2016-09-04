using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject trackedObject;
    private Vector3 trackedObjectPosition;

    public float trackingSpeed;

    // Use this for initialization
    void Start () {
            
    }

    // Update is called once per frame
    void Update () {
        trackedObjectPosition = new Vector3(
            trackedObject.transform.position.x,
            trackedObject.transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, trackedObjectPosition, trackingSpeed * Time.deltaTime);
    }
}
