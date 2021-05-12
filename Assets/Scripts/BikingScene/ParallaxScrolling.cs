using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    private float length, startPosition;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float moved = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (moved > startPosition + length) startPosition += length;
        else if (moved < startPosition - length) startPosition -= length;
    }
}
