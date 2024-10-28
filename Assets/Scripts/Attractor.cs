using UnityEngine;

public static class Attractor
{
    public static void Attract(Planet current, Planet other, float G)
    {
        if (other == null || current == other) return;

        Vector3 direction = current.transform.position - other.transform.position;
        direction.Normalize();
        float distance = direction.magnitude + 0.1f;

        float forceMagnitude = G * (other.mass * current.mass) / (distance * distance);
        Vector3 acceleration = forceMagnitude * direction / other.mass;

        other.currentVelocity += acceleration * Time.fixedDeltaTime;

        other.rb.position += other.currentVelocity * Time.fixedDeltaTime;
    }
    
}
