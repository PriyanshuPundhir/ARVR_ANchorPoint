using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class tapToJump : MonoBehaviour
{
    public List<Vector3> jumpPositions = new List<Vector3>();
    private ARPlaneManager m_ARPlaneManager;
    private ARPlane aRPlane;
    public float speed = 2.0F;
    public Transform startMarker;
    public Transform endMarker;
    private float startTime;
    void Start()
    {
        InvokeRepeating("jump", 1.0f, 0.01f);
    }
    public void jump()
    {
        GameObject cube = GameObject.FindGameObjectWithTag("jumper");
       // while (cube.transform.position != jumpPositions[1])
        {
            if (cube != null)
            {
                //cube.transform.position = jumpPositions[1];
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, jumpPositions[1], 
                    (float) speed * Time.deltaTime);
            }
        }
    }
    

    public void TogglePlaneDetection()
    {
        aRPlane.GetComponent<ARPlane>();

        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;

        string planeDetectionMessage = "";
        if (m_ARPlaneManager.enabled)
        {
            planeDetectionMessage = "Disable Plane Detection and Hide Existing";

        }
        else
        {
            planeDetectionMessage = "Enable Plane Detection and Show Existing";
        }

    }
}
