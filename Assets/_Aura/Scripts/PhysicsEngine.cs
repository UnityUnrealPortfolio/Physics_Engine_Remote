using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{

    public List<Vector3> forceVectorList = new List<Vector3>();
    [SerializeField] private Vector3 velocityVector = Vector3.zero;
    [SerializeField] private Vector3 accelerationVector = Vector3.zero;
    [SerializeField] private Vector3 sumOfForces = Vector3.zero;
    [SerializeField] float mass;
    private void Start()
    {
        //AddForces();
    }
    private void FixedUpdate()
    {
        AddForces();
        UpdateVelocity();

        transform.position += velocityVector * Time.deltaTime;
    }

    private void UpdateVelocity()
    {
        //acceleration = sumOfForces/mass
        accelerationVector = sumOfForces / mass;
        velocityVector += accelerationVector * Time.deltaTime;//because velocity increases the longer you accelerate

    }

    private void AddForces()
    {
        //set to zero each time we call this
        sumOfForces = Vector3.zero;

        for (int i = 0; i < forceVectorList.Count; i++)
        {
            sumOfForces += forceVectorList[i];
        }

    }
}
