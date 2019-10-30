using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRotation : MonoBehaviour
{
    public float speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.RotateAround(transform.position, Vector3.up, -speed * Time.deltaTime);
    }
}
