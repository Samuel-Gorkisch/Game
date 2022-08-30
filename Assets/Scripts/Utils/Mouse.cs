using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Utils
{
    public class Mouse
    {
        public static Vector3 GetWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
