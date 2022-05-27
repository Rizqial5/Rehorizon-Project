using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rehorizon.CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float speed = 4;
        [SerializeField] float zoomSpeed = 10;

        CameraMover mover;

        private void Start() 
        {
            mover = GetComponent<CameraMover>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.mouseScrollDelta.y <= 0f)
            {
                mover.ZoomMovement(zoomSpeed);
            }
            if(Input.mouseScrollDelta.y >= 0f)
            {
                mover.ZoomMovement(-zoomSpeed);
            }

            

            if(Input.GetKey(KeyCode.D))
            {
                mover.Movement(1,0,speed);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                mover.Movement(-1,0,speed);
            }

            if(Input.GetKey(KeyCode.W))
            {
                mover.Movement(0,1,speed);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                mover.Movement(0,-1,speed);
            }
        }
    }
}
