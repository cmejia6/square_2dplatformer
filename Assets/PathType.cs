using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PathMovement { Move, Jump }
public class PathType : MonoBehaviour {
    public PathMovement pathMovement;
    public float jumpForce;
    public float jumpDirection;
}