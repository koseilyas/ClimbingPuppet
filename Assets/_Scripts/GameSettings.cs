
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Range(4.0f, 8.0f)]
    public float playerStartingJumpSpeed; //6
    
    [Range(1.0f, 3.0f)]
    public float playerSpeedDeacceleration; //2

    [Range(-2000.0f, -1000.0f)]
    public float dynamiteExplodeForce; // -1500
    
    [Range(-1500.0f, -500.0f)]
    public float katanaExplodeForce; // -1000
    
}
