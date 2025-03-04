using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terresquall;

public class MobileInput : IInput
{
    public event System.Action<Vector3> OnMoveInput;
    public event System.Action<Touch> OnTouchInput;


    public void Update()
    {
        Vector3 movement = new Vector3(VirtualJoystick.GetAxis("Horizontal"), 0, VirtualJoystick.GetAxis("Vertical"));
        if (movement != Vector3.zero)
        {
            OnMoveInput?.Invoke(movement);
        }

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (IsTouchInArea(touch.position))
                {
                    OnTouchInput?.Invoke(touch);
                }
            }
        }
    }

    private bool IsTouchInArea(Vector2 touchPosition)
    {
        float screenWidth = Screen.width;
        float areaWidth = screenWidth / 8;

        return touchPosition.x > (screenWidth - 5 * areaWidth);
    }

}
