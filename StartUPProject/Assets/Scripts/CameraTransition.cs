using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    Camera camera;


    Transform referenceTransform;
    Transform targetTransform;
    float timer;

    public void Start(){
        
    }

    public void Update()
    {
        Transition();        
    }

    public void StartTransition(Transform source, Transform target) {
        timer = 0;
        referenceTransform = source;
        targetTransform = target;
    }

    public void Transition() {
        timer += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(referenceTransform.rotation, targetTransform.rotation, timer);
        transform.position = Vector3.Slerp(referenceTransform.position, targetTransform.position, timer);
    }
}
