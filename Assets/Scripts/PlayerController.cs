using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OppositeCar"))
        {
            GameObject route = GameObject.Find("Road");
            GameObject herbe = GameObject.Find("Grass");

            if (route != null)
                route.GetComponent<Scrolling>().enabled = false;

            if (herbe != null)
                herbe.GetComponent<Scrolling>().enabled = false;

            WheelRotation[] roues = GetComponentsInChildren<WheelRotation>();
            foreach (WheelRotation roue in roues)
            {
                roue.enabled = false;
            }

            GameObject spawn = GameObject.Find("Spawn");
            if (spawn != null)
            {
                Traffic trafficScript = spawn.GetComponent<Traffic>();
                if (trafficScript != null)
                {
                    trafficScript.StopSpawn();
                }
            }

            Destroy(this); 
        }
    }
}
