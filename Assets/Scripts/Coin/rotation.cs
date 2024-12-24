using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 80f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.Self);
    }
}