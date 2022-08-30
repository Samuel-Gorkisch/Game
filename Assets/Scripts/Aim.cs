using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Utils;

public class Aim : MonoBehaviour
{
    private Transform aimTransform;

    private Vector3 lastMouseWorldPosition = Vector3.zero;
    public enum Direction { Left, Right, Neutral };

    public Direction lastMoveDirection;

    void Awake()
    {
        aimTransform = transform.Find("Aim");
        lastMoveDirection = Direction.Neutral;
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Mouse.GetWorldPosition();
        Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        int topAngleToSwitch = 90;
        int bottomAngleToSwitch = -90;

        if (lastMoveDirection == Direction.Left || mouseWorldPosition.x < lastMouseWorldPosition.x)
        {
            topAngleToSwitch = 110;
            bottomAngleToSwitch = -110;
        }
        else if (lastMoveDirection == Direction.Right || mouseWorldPosition.x > lastMouseWorldPosition.x)
        {
            topAngleToSwitch = 70;
            bottomAngleToSwitch = -70;
        }

        if (mouseWorldPosition.x < lastMouseWorldPosition.x)
        {
            lastMoveDirection = Direction.Left;
        }
        else if (mouseWorldPosition.x > lastMouseWorldPosition.x)
        {
            lastMoveDirection = Direction.Right;
        }

        lastMouseWorldPosition = mouseWorldPosition;

        Vector3 localScale = Vector3.one;
        if (Mathf.Round(angle) > topAngleToSwitch || Mathf.Round(angle) < bottomAngleToSwitch)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;

        }
        aimTransform.localScale = localScale;
    }
}
