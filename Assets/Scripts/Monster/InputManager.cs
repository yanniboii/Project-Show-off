using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager2 : MonoBehaviour
{

    public static InputManager2 Instance { get; private set; }

    public controlSet p1;
    public controlSet p2;
    public controlSet p3;
    public controlSet p4;

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        p1 = new controlSet();
        p2 = new controlSet();
        p3 = new controlSet();
        p4 = new controlSet();
    }

    // Update is called once per frame
    void Update()
    {
        
        p1.left = new Vector2(Input.GetAxisRaw("p1jlX"), Input.GetAxisRaw("p1jlY"));
        p1.right = new Vector2(Input.GetAxisRaw("p1jrX"), Input.GetAxisRaw("p1jrY"));
        p1.button1 = Input.GetAxisRaw("p1b0");
        p1.rightBumper = Input.GetAxisRaw("p1r2");



        p2.left = new Vector2(Input.GetAxisRaw("p2jlX"), Input.GetAxisRaw("p2jlY"));
        p2.right = new Vector2(Input.GetAxisRaw("p2jrX"), Input.GetAxisRaw("p2jrY"));
        p2.button1 = Input.GetAxisRaw("p2b0");
        p2.rightBumper = Input.GetAxisRaw("p2r2");

        p3.left = new Vector2(Input.GetAxisRaw("p3jlX"), Input.GetAxisRaw("p3jlY"));
        p3.right = new Vector2(Input.GetAxisRaw("p3jrX"), Input.GetAxisRaw("p3jrY"));
        p3.button1 = Input.GetAxisRaw("p3b0");
        p3.rightBumper = Input.GetAxisRaw("p3r2");

        p4.left = new Vector2(Input.GetAxisRaw("p4jlX"), Input.GetAxisRaw("p4jlY"));
        p4.right = new Vector2(Input.GetAxisRaw("p4jrX"), Input.GetAxisRaw("p4jrY"));
        p4.button1 = Input.GetAxisRaw("p4b0");
        p4.rightBumper = Input.GetAxisRaw("p4r2");
    }

    public controlSet GetControlSet(int _index)
    {
        switch (_index)
        {
            case 0:
                return p1;
            case 1:
                return p2;
            case 2:
                return p3;
            case 3:
                return p4;

            default:
                return p1;
        }
    }
}

[System.Serializable]
public struct controlSet
{
    public Vector2 left;
    public Vector2 right;
    public float button1;
    public float rightBumper;
}
