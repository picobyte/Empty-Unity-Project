using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

public Vector3 offset;
public float speed = 10;

    public Transform target;    
    // Update is called once per frame
    void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position, offset + target.position, Time.deltaTime*speed);
    }
}
