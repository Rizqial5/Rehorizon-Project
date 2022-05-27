using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.CameraControl
{
    public class CameraMover : MonoBehaviour
    {
        public void Movement(float x, float y, float speed)
        {
            transform.position += new Vector3(x,y) * Time.deltaTime * speed ;
        }

        public void ZoomMovement(float speed)
        {
            Camera.main.orthographicSize += speed * Time.deltaTime;
        }
    }
}
