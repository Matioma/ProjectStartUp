using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [SerializeField]
    float waterLevel;
    [SerializeField]
    float floatHeight;
    [SerializeField]
    Vector3 buoyancyCentreOffset;
    [SerializeField]
    float bounceDamp ;
 
 
 
     void FixedUpdate()
        {
            var actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
            var forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

            if (forceFactor > 0f)
            {
                var uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp);
                GetComponent<Rigidbody>().AddForceAtPosition(uplift, actionPoint);
            }
    }
}
