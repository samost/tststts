using UnityEngine;

namespace RotationCamera
{
    public class CameraRotation : MonoBehaviour
    {
        public float sensX, sensY;
        public Vector2 MinMaxY = new Vector2(-40, 40);
        public Vector2 MinMaxX = new Vector2(-360, 360);
        
        private float moveY, moveX;

        private void Update()
        {
            moveY -= Input.GetAxis("Mouse Y") * sensY;
            moveY = ClampAngle(moveY, MinMaxY.x, MinMaxY.y);

            moveX += Input.GetAxis("Mouse X") * sensX;
            moveX = ClampAngle(moveX, MinMaxX.x, MinMaxX.y);

            transform.rotation = Quaternion.Euler(moveY, moveX, 0);
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
            {
                angle += 360f;
            }

            if (angle > 360f)
            {
                angle -= 360f;
            }

            return Mathf.Clamp(angle, min, max);
        }
    }
}