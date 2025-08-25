using UnityEngine;

public class CarDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OppositeCar"))
        {
            GameObject spawn = GameObject.Find("Spawn");
            if (spawn != null)
            {
                Traffic trafficScript = spawn.GetComponent<Traffic>();
                if (trafficScript != null)
                {
                    trafficScript.IncreaseCarCount();
                }
            }

            Destroy(collision.gameObject);
        }
    }
}
