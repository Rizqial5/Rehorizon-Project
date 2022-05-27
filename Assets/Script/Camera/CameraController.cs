using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rehorizon.CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float speed = 4;
        [SerializeField] float zoomSpeed = 10;
        [SerializeField] float zoomOutBoundary = 7;
        [SerializeField] float zoomInBoundary = 2;

        CameraMover mover;

        private void Start() 
        {
            mover = GetComponent<CameraMover>();
            Camera.main.orthographicSize = 5;
        }

        // Update is called once per frame
        void Update()
        {
            ZoomController();

            if (Input.GetKey(KeyCode.D))
            {
                mover.Movement(1, 0, speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                mover.Movement(-1, 0, speed);
            }

            if (Input.GetKey(KeyCode.W))
            {
                mover.Movement(0, 1, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                mover.Movement(0, -1, speed);
            }
        }

        private void ZoomController()
        {
            if (Input.mouseScrollDelta.y <= 0f)
            {
                if(!mover.ZoomOutBoundary(zoomOutBoundary)) return;

                mover.ZoomMovement(zoomSpeed);
            }
            if (Input.mouseScrollDelta.y >= 0f)
            {
                if(!mover.ZoomInBoundary(zoomInBoundary)) return;
                
                mover.ZoomMovement(-zoomSpeed);
            }
        }
    }
}
