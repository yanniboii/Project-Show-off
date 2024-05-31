using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTracking : MonoBehaviour
{

    public GameObject player;

    public enum areas
    {
        area1,
        area2,
        area3,
        area4,
        area5,
        area6,
    }

    public areas currentArea;
    public Camera mainCamera;
    public BoxCollider area1;
    public BoxCollider area2;
    public BoxCollider area3;
    public BoxCollider area4;
    public BoxCollider area5;
    public BoxCollider area6;

    private void Update()
    {
        
    }
}
