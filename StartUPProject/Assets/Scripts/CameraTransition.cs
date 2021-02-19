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

   void Start(){
        
    }

    void Update()
    {
        if (referenceTransform == null || targetTransform == null) return;

        Transition();        
    }

    public void StartTransition(Transform target) {
        timer = 0;
        referenceTransform = camera.transform;
        targetTransform = target;
    }

    public void Transition() {
        Debug.Log(timer);

        timer += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(referenceTransform.rotation, targetTransform.rotation, timer);
        transform.position = Vector3.Slerp(referenceTransform.position, targetTransform.position, timer);
    }
}
