using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animation))]


public class RandomAnimation : MonoBehaviour
{
    [SerializeField]
    AnimationClip[] animations;
    void Start()
    {
        GetRandomAnimation();
        GetComponent<Animation>().Play();
    }

    void GetRandomAnimation() {
        GetComponent<Animation>().clip = animations[Random.Range(0, animations.Length)];
    }
}
