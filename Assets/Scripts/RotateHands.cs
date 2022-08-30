using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Utils;

public class RotateHands : MonoBehaviour
{
    public GameObject hands;

    private Transform aimTransform;

    private Vector3 lastMouseWorldPosition = Vector3.zero;

    void Awake()
    {
        aimTransform = hands.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Mouse.GetWorldPosition();
        Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        int topAngleToSwitch = 90;
        int bottomAngleToSwitch = -90;

        if (mouseWorldPosition.x < lastMouseWorldPosition.x)
        {
            topAngleToSwitch = 110;
            bottomAngleToSwitch = -110;
        } else if (mouseWorldPosition.x > lastMouseWorldPosition.x)
        {
            topAngleToSwitch = 70;
            bottomAngleToSwitch = -70;
        }

        lastMouseWorldPosition = mouseWorldPosition;

        Vector3 localScale = Vector3.one;
        if (angle > topAngleToSwitch || angle < bottomAngleToSwitch)
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
