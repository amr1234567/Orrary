using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera Camera_Sun_Top_View;
    public Camera SideView;
    public Camera Camera_Earth;
    public Camera Camera_Earth_Top;
    public Camera Movable_Camera;
    private int Camera_Handler = 4;


    public void Awake()
    {
        if (Camera_Sun_Top_View == null)
        {
            Debug.Log("ERROR");
        }
    }

    private void Handling()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            Camera_Handler++;
            if (Camera_Handler > 4)
                Camera_Handler = 0;
        }


        if (Camera_Handler == 0)
        {
            Camera1();
        }
        else if (Camera_Handler == 1)
        {
            Camera2();
        }
        else if (Camera_Handler == 2)
        {
            Camera3();
        }
        else if (Camera_Handler == 3)
        {
            Camera4();
        }
        else if (Camera_Handler == 4)
        {
            Camera5();
        }
    }

    private void Camera5()
    {
        Camera_Sun_Top_View.enabled = false;
        SideView.enabled = false;
        Camera_Earth.enabled = false;
        Camera_Earth_Top.enabled = false;
        Movable_Camera.enabled = true;
    }

    private void Camera1()
    {
        Camera_Sun_Top_View.enabled = true;
        SideView.enabled = false;
        Camera_Earth.enabled = false;
        Movable_Camera.enabled = false;
        Camera_Earth_Top.enabled = false;
    }

    private void Camera2()
    {
        Camera_Sun_Top_View.enabled = false;
        SideView.enabled = true;
        Camera_Earth.enabled = false;
        Movable_Camera.enabled = false;
        Camera_Earth_Top.enabled = false;
    }

    private void Camera3()
    {
        Camera_Sun_Top_View.enabled = false;
        SideView.enabled = false;
        Camera_Earth.enabled = true;
        Movable_Camera.enabled = false;
        Camera_Earth_Top.enabled = false;
    }

    private void Camera4()
    {
        Camera_Sun_Top_View.enabled = false;
        SideView.enabled = false;
        Camera_Earth.enabled = false;
        Movable_Camera.enabled = false;
        Camera_Earth_Top.enabled = true;
    }

    private void Update()
    {
        if (Camera_Earth_Top == null)
        {
            Debug.Log("BUG");
        }
        Handling();
    }
}
