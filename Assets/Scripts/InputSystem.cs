using UnityEngine;

public class InputSystem
{
    private Vector2 _lastPos;

    public float GetDifference()
    {
        #region Android

        //
        // if (Input.touches[0].phase == TouchPhase.Began)
        // {
        //     LastPos = Input.touches[0].position;
        // }
        //
        // if (Input.touches[0].phase == TouchPhase.Moved)
        // {
        //     return (Input.touches[0].position - LastPos).x;
        // }

        #endregion


        #region PC

        if (Input.GetMouseButtonDown(0)) _lastPos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            var mousePositionX = Input.mousePosition.x - _lastPos.x;
            _lastPos = Input.mousePosition;
            return mousePositionX;
        }

        #endregion

        return 0;
    }
}