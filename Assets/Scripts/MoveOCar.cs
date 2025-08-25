using UnityEngine;

public class MoveOCar : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}