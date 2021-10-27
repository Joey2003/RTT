using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour
{

    private static readonly float PanSpeed = 20f;
    private static readonly float ZoomSpeedTouch = 0.1f;
    private static readonly float ZoomSpeedMouse = 0.5f;

    private static readonly float[] BoundsX = new float[] { -52.7f, -32.7f };
    private static readonly float[] BoundsZ = new float[] { 40.2f, 60.2f };
    private static readonly float[] ZoomBounds = new float[] { 25f, 85f };

    private Camera cam;

    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only

    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only

    public InvokeCam invoker_1;
    private bool invoker_2;
    public SidePanel invoker_3;
    public Exit invoker_4;
    public Items invoker_5;
    public Items invoker_6;
    public Items invoker_7;
    public Items invoker_8;
    public Shop invoker_9;
    public Options invoker_10;
    public EditRay ray;
    
    public bool invoked;
    bool editInvoke, specialInvoke;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {

        if (ray.editMode)
        {


            foreach (GameObject editable in GameObject.FindGameObjectsWithTag("Editable"))
            {
                if (editable.GetComponent<Snap>().invoke)
                {
                    editInvoke = true;
                    break;
                } else
                {
                    editInvoke = false;
                }
            }

            foreach (GameObject special in GameObject.FindGameObjectsWithTag("Special_Editable"))
            {
                if (special.GetComponent<Snap>().invoke)
                {
                    specialInvoke = true;
                    break;
                }
                else
                {
                    specialInvoke = false;
                }
            }

            if (editInvoke || specialInvoke)
            {
                invoker_2 = true;
            } else
            {
                invoker_2 = false;
            }
        }

        if (   (invoker_1 != null && invoker_1.invoke == true)
            || (invoker_2)
            || (invoker_3 != null && invoker_3.invoke == true)
            || (invoker_4 != null && invoker_4.invoke == true)
            || (invoker_5 != null && invoker_5.invoke == true)
            || (invoker_6 != null && invoker_6.invoke == true)
            || (invoker_7 != null && invoker_7.invoke == true)
            || (invoker_8 != null && invoker_8.invoke == true)
            || (invoker_9 != null && invoker_9.invoke == true)
            || (invoker_10 != null && invoker_10.invoke == true))
        {
            invoked = true;
        } else
        {
            invoked = false;
        }

        if (!invoked) 
        {
            if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
            {
                HandleTouch();
            }
            else
            {
                HandleMouse();
            }
        }
    }
    public void Invoke(bool invoke)
    {
        invoked = invoke;
    }

    void HandleTouch()
    {
        switch (Input.touchCount)
        {

            case 1: // Panning
                wasZoomingLastFrame = false;

                // If the touch began, capture its position and its finger ID.
                // Otherwise, if the finger ID of the touch doesn't match, skip it.
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                }
                else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved)
                {
                    PanCamera(touch.position);
                }
                break;

            case 2: // Zooming
                Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
                if (!wasZoomingLastFrame)
                {
                    lastZoomPositions = newPositions;
                    wasZoomingLastFrame = true;
                }
                else
                {
                    // Zoom based on the distance between the new positions compared to the 
                    // distance between the previous positions.
                    float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                    float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                    float offset = newDistance - oldDistance;

                    ZoomCamera(offset, ZoomSpeedTouch);

                    lastZoomPositions = newPositions;
                }
                break;

            default:
                wasZoomingLastFrame = false;
                break;
        }
    }

    void HandleMouse()
    {
        // On mouse down, capture it's position.
        // Otherwise, if the mouse is still down, pan the camera.
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            PanCamera(Input.mousePosition);
        }

        // Check for scrolling to zoom the camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, ZoomSpeedMouse);
    }

    void PanCamera(Vector3 newPanPosition)
    {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.y * PanSpeed, 0, offset.x * -PanSpeed);

        // Perform the movement
        transform.Translate(move, Space.World);

        // Ensure the camera remains within bounds.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        // Cache the position
        lastPanPosition = newPanPosition;
    }

    void ZoomCamera(float offset, float speed)
    {
        if (offset == 0)
        {
            return;
        }

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
    }

}