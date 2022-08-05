using System;
using UnityEngine;
using Obi;
// using System.Random
// using System.Collections.Generic;

[RequireComponent(typeof(ObiSolver))]
public class SolidifyOnContact : MonoBehaviour
{
    public struct SolidData
    {
        public Transform reference;
        public Vector3 localPos;

        public SolidData(Transform reference)
        {
            this.reference = reference;
            this.localPos = Vector3.zero;
        }
    };

    public Color paintColor;
    
    public float minRadius = 0.05f;
    public float maxRadius = 0.2f;
    public float strength = 1;
    public float hardness = 1;
    public GameObject decalPrefab;

    ObiSolver solver;
    public Color solidColor;

    public SolidData[] solids = new SolidData[0];

	void Awake()
	{
		solver = GetComponent<ObiSolver>();
	}

    void OnEnable()
	{
        // solver.OnBeginStep += Solver_OnBeginStep;
        solver.OnCollision += Solver_OnCollision;
        // solver.OnParticleCollision += Solver_OnParticleCollision;
    }

	void OnDisable()
	{
        // solver.OnBeginStep -= Solver_OnBeginStep;
        solver.OnCollision -= Solver_OnCollision;
        // solver.OnParticleCollision -= Solver_OnParticleCollision;
    }

    void Solver_OnCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
	{
        // resize array to store one reference transform per particle:
        Array.Resize(ref solids, solver.allocParticleCount);

		var colliderWorld = ObiColliderWorld.GetInstance();

		for (int i = 0; i < e.contacts.Count; ++i)
		{
			if (e.contacts.Data[i].distance < 0.001f)
			{


				var col = colliderWorld.colliderHandles[e.contacts.Data[i].bodyB].owner;
                if (col.gameObject.tag == "enemy"){
                    UnityEngine.AI.NavMeshAgent nav = col.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
                    nav.speed = 0.0f;
                    // Destroy(col.gameObject.GetComponent<UnityEngine.Animator>());
                }
                if (col.gameObject.tag == "Player"){
                    Move.playerSpeed = 0.0f;
                    
                }

                // if (col.gameObject.name == "Planks"){
                //     int particleIndex = solver.simplices[e.contacts.Data[i].bodyA];
                //     var position = solver.positions[particleIndex];
                //     Vector3 pos = new Vector3(position.x, position.y, position.z);
                //     Debug.Log(pos);
                //     Instantiate(decalPrefab, pos, Quaternion.Euler(90f, 0f, 0f));
                // }
                Debug.Log(col.gameObject.name);
                // Solidify(solver.simplices[e.contacts.Data[i].bodyA], new SolidData(col.transform));
			}
		}

	}

    void Solver_OnParticleCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
    {
        for (int i = 0; i < e.contacts.Count; ++i)
        {
            if (e.contacts.Data[i].distance < 0.001f)
            {
                int particleIndexA = solver.simplices[e.contacts.Data[i].bodyA];
                int particleIndexB = solver.simplices[e.contacts.Data[i].bodyB];

                if (solver.invMasses[particleIndexA] < 0.0001f && solver.invMasses[particleIndexB] >= 0.0001f)
                    Solidify(particleIndexB, solids[particleIndexA]);
                if (solver.invMasses[particleIndexB] < 0.0001f && solver.invMasses[particleIndexA] >= 0.0001f)
                    Solidify(particleIndexA, solids[particleIndexB]);
            }
        }

    }

    void Solver_OnBeginStep(ObiSolver s, float stepTime)
    {
        for (int i = 0; i < solids.Length; ++i)
        {
            if (solver.invMasses[i] < 0.0001f)
            {
                solver.positions[i] = solver.transform.InverseTransformPoint(solids[i].reference.TransformPoint(solids[i].localPos));
            }
        }
    }

    void Solidify(int particleIndex, SolidData solid)
    {
        // remove the 'fluid' flag from the particle, turning it into a solid granule:
        solver.phases[particleIndex] &= (int)(~ObiUtils.ParticleFlags.Fluid);

        // fix the particle in place (by giving it infinite mass):
        solver.invMasses[particleIndex] = 0;

        // and change its color:
        solver.colors[particleIndex] = solidColor;

        // set the solid data for this particle:
        solid.localPos = solid.reference.InverseTransformPoint(solver.transform.TransformPoint(solver.positions[particleIndex]));
        Debug.Log(solid.localPos);
        solids[particleIndex] = solid;
    }


    void Paint(int particleIndex, SolidData solid, Paintable p){
        Debug.Log("in Paint!");
        Vector3 pos = solid.reference.InverseTransformPoint(solver.transform.TransformPoint(solver.positions[particleIndex]));
        // pos = new Vector3(11.44f, -0.17f, -11.221f);
        // float radius = Random.Range(minRadius, maxRadius);
        Instantiate(decalPrefab, pos, Quaternion.Euler(90f, 0f, 0f));
        float radius = maxRadius;
        Debug.Log("this is p:  "+pos);
        // Debug.Log(p);
        PaintManager.instance.paint(p, pos, radius, hardness, strength, paintColor);
    }
}
