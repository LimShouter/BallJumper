using System;
using Game.Part;
using UnityEngine;

public class Player : MonoBehaviour
{
    [NonSerialized]public float Speed;
    public float sensitivity;
    public float maxSpeed;
    public float acceleration;
    public float distanceBetweenOthers;
    public PartPullContainer partPullContainer;
}