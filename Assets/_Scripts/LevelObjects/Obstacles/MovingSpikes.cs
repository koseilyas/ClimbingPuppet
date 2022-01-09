using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MovingSpikes : MonoBehaviour , IDeadly
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    public void Execute()
    {
        pathCreator = null;
    }
}
