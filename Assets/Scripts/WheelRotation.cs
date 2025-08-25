using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private int speed = 800;
    [SerializeField] private Vector3 direction = Vector3.right;

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}