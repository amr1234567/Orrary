using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateScript : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;
    public void NavigateTo(Vector3 dist)
    {
        cam.transform.position = dist + offset;
    }
}
