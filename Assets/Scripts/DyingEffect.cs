﻿using System.Collections;
using Assets.Scripts;
using UnityEngine;

public class DyingEffect : MonoBehaviour
{
    //TODO Adjust TimeScaling of Particles
    [SerializeField]
    GameObject ParticleSpawnPoint;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    private float cubesPivotDistance;
    private Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ExplodeAfterSeconds(0f));
    }

    
    private IEnumerator ExplodeAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        Explode();
    }

   public void Explode()
   {
       //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
       for (int x = 0; x < cubesInRow; x++)
       {
           for (int y = 0; y < cubesInRow -2; y++)
           {
               for (int z = 0; z < cubesInRow; z++)
               {
                   createPiece(x, y, z);
               }
           }
       }

       //get explosion position
       Vector3 explosionPos = ParticleSpawnPoint.transform.position;
       //get colliders in that position and radius
       Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
       {
           //get rigidbody from collider object
           Rigidbody rb = hit.GetComponent<Rigidbody>();
           if (rb != null)
           {
               //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
           }
       }

   }

   void createPiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.layer = Layers.Particles;
        

            //set piece position and scale
        piece.transform.position = ParticleSpawnPoint.transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        var rb = piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<Renderer>().material.color = Color.red;
        Destroy(piece,5f);
    }
}
