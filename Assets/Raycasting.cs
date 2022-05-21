using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class Raycasting : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    private void Awake()
    {
        aRRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        aRPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        // assetno = ObjectSelectionScript.ObjectNo;  // Remove this if spawning single object or set  :  assetno = 1
    }


    //Enable Disable Planes
    public void SetAllPlanes(bool value)
    {
        foreach (var plane in aRPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }








}