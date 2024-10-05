using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private float zoom;
    public float sensitivity = 5f;

    public Vector3 mouseMovement;
    public Vector2 rotation;

    private bool TriggerPlanet;
    private Vector3 PlanetPostion;
    private Vector3 LastCamStandPosition;

    public float scrollSensitivity = 130f;  // New sensitivity for zoom movement

    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.fieldOfView;
        mouseMovement = Vector3.zero;
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        rotation.x = currentRotation.y;
        rotation.y = currentRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerPlanet)
        {
            transform.position = PlanetPostion + new Vector3(0, 50, 0);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Left click drag to pan (slide view horizontally and vertically)
        if (Input.GetMouseButton(0))
        {
            // Adjust the position of the camera based on the mouse drag, relative to the camera's perspective
            mouseMovement.x = Input.GetAxis("Mouse X") * sensitivity;
            mouseMovement.z = Input.GetAxis("Mouse Y") * sensitivity;

            // Move the camera along its local right (X) and up (Y) directions
            transform.Translate(new Vector3(-mouseMovement.x, -mouseMovement.z, 0), Space.Self);
        }

        // Right click drag to rotate the camera view
        else if (Input.GetMouseButton(1))
        {
            rotation.x += Input.GetAxis("Mouse X") * sensitivity;
            rotation.y += Input.GetAxis("Mouse Y") * sensitivity;  // Inverted to mimic common camera behavior

            // Clamp the vertical rotation to prevent flipping
            rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

            // Apply the rotation based on X (horizontal) and Y (vertical) axes
            transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0f);
        }

        // Zoom in/out by moving the camera forward/backward using the scroll wheel
        if (scroll != 0)
        {
            Vector3 zoomDirection = transform.forward * scroll * scrollSensitivity;

            // Move the camera forward (zoom in) or backward (zoom out)
            transform.position += zoomDirection;

        }
    }

    public void Trigger(Vector3 objectDist)
    {
        LastCamStandPosition = transform.position;
        TriggerPlanet = true;
        PlanetPostion = objectDist;
    }

    public void UnTrigger()
    {
        TriggerPlanet = false;
        PlanetPostion = Vector3.zero;
        transform.position = LastCamStandPosition;
    }
}
