using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbleCamera : MonoBehaviour
{
    [SerializeField] public Player player;

    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float maxVerticalAngle = 85f;

    private float pitch = 0f;
    private float yaw = 0f;

    bool noPlayer = true;
    Vector2 rotation = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (player != null)
        {
            if (noPlayer)
            {
                player.beforeRotate += OnCameraRotated;
                noPlayer = false;
            }

            float rightStickHorizontal = -rotation.x;
            float rightStickVertical = rotation.y;

            yaw += rightStickHorizontal * rotationSpeed * Time.deltaTime;
            pitch -= rightStickVertical * rotationSpeed * Time.deltaTime;

            pitch = Mathf.Clamp(pitch, -maxVerticalAngle, maxVerticalAngle);

            transform.rotation = Quaternion.Euler(-pitch, -yaw, 0f);
        }
    }

    void OnCameraRotated(Vector2 vector2)
    {
        rotation = vector2;
    }
}
