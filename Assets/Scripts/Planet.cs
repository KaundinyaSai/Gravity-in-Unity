using UnityEngine;
using System.Collections.Generic;

public class Planet : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 startingVelocity;
    [HideInInspector] public Vector3 currentVelocity;

    [HideInInspector] public Rigidbody rb;
    private Planet[] planets;

    Universe universe;

    public List<Vector3> orbitPath = new List<Vector3>();
    public int maxOrbitPoints = 100;

    void Start() {
        universe = GameObject.FindGameObjectWithTag("Manager").GetComponent<Universe>();
        
        rb = GetComponent<Rigidbody>();
        currentVelocity = startingVelocity;
        
        planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
    }

    void FixedUpdate() {
        // Attract each planet to every other planet
        foreach(Planet other in planets) {
            if (other == this) continue;
            Attractor.Attract(this, other, universe.G);
        }

        orbitPath.Add(transform.position);

        if (orbitPath.Count > maxOrbitPoints) {
            orbitPath.RemoveAt(0);
        }
    }

    private void OnDrawGizmos() {
        if(Application.isPlaying){
            DrawOrbit();
        }
    }
    void DrawOrbit(){
        Gizmos.color = Color.green;

        for(int i = 0; i < orbitPath.Count - 1; i++){
            Gizmos.DrawLine(orbitPath[i], orbitPath[i + 1]);
        }
    }

}

