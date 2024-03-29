using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MovingSpikes : MonoBehaviour , IDeadly
{
    [SerializeField] private Vector3 _explodeForce;
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;
    
    private void Start()
    {
        _explodeForce.z = GameManager.Instance.gameSettings.katanaExplodeForce;
    }

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

    public Vector3 GetExplodeVector()
    {
        return _explodeForce;
    }
}
