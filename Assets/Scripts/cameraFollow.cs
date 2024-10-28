using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // VEry simple camera follow script.
    public Planet centrePlanet;
    public Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = centrePlanet.transform.position + offset;
    }
}
