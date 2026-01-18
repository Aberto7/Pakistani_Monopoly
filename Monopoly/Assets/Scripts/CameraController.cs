using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Monopoly
{
    public class CameraController : MonoBehaviour {
    
        public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
        private RotationAxes axes = RotationAxes.MouseXAndY;
        private float sensitivityRotate = 5F;
        private float sensitivityTranslate = 0.5F;
        private float minimumY = -90F;
        private float maximumY = 90F;
        float rotationY = -90F;

        private float lerpSpeed = 10.0f;

        public static bool viewDiceRoll = false;

        void Update()
        {
            if (viewDiceRoll) {
                LerpDiceRoll();
            }
            else
            {
                MouseInput();
                KeyboardInput();
            }
        }

        void LerpDiceRoll()
        {
            CameraFollow.isFollowing = false; 
            Vector3 viewDicePos = new Vector3(0, 55, 1);
            this.transform.position = Vector3.Lerp(this.transform.position, viewDicePos, lerpSpeed*Time.deltaTime);
            this.transform.LookAt(Vector3.zero); 

            if (this.transform.position == viewDicePos) {
                viewDiceRoll = false;
            }
        }

        void KeyboardInput()
        {
            if(Input.GetKey(KeyCode.DownArrow)) 
            {
                Vector3 pos = transform.position;
                pos = pos - transform.forward*sensitivityTranslate;
                transform.position = pos;
            }
            else if(Input.GetKey(KeyCode.UpArrow)) 
            {
                Vector3 pos = transform.position;
                pos = pos + transform.forward*sensitivityTranslate;
                transform.position = pos;
            }
            else if(Input.GetKey(KeyCode.LeftArrow)) 
            {
                Vector3 pos = transform.position;
                pos = pos - transform.right*sensitivityTranslate;
                transform.position = pos;
            }
            else if(Input.GetKey(KeyCode.RightArrow)) 
            {
                Vector3 pos = transform.position;
                pos = pos + transform.right*sensitivityTranslate;
                transform.position = pos;
            }
        }

        void MouseInput()
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(Input.touchCount > 0 ? Input.GetTouch(0).fingerId : -1))
            {
                return;
            }

            if (Input.touchCount == 2)
            {
                MouseWheeling();
            }
            else if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                MouseLeftClick();
            }
            else
            {
                MouseWheeling(); 
            }
        }

        void MouseLeftClick()
        {
            float deltaX, deltaY;

            if (Input.touchCount > 0)
            {
                deltaX = Input.GetTouch(0).deltaPosition.x * 0.2f;
                deltaY = Input.GetTouch(0).deltaPosition.y * 0.2f;
            }
            else
            {
                deltaX = Input.GetAxis("Mouse X");
                deltaY = Input.GetAxis("Mouse Y");
            }

            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + deltaX * sensitivityRotate;

                rotationY += deltaY * sensitivityRotate;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, deltaX * sensitivityRotate, 0);
            }
            else
            {
                rotationY += deltaY * sensitivityRotate;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }

        void MouseWheeling()
        {
            Vector3 pos = transform.position;

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                pos = pos - transform.forward * deltaMagnitudeDiff * (sensitivityRotate * 0.01f);
                transform.position = pos;
            }
            else
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    pos = pos - transform.forward * sensitivityRotate;
                    transform.position = pos;
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    pos = pos + transform.forward * sensitivityRotate;
                    transform.position = pos;
                }
            }
        }
    }
}