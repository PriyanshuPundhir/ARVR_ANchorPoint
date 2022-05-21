using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class taptospawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnGO, cube;
    private ARRaycastManager aRRaycastManager;
    private tapToJump tJump;

    private Vector2 touchPosition;
    private GameObject instanceGO;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool waitTime = true;
    private int anchorCount = 0;
    private void Awake()
    {
        tJump = FindObjectOfType<tapToJump>();
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool tryGetTouchPos(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchPosition = default;
            return false;
        }
    }

    void Update()
    {
        if(!tryGetTouchPos(out touchPosition))
        {
            return;
        }
        if(aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;

            if(waitTime && anchorCount < 2)
            {
                anchorCount++;
                waitTime = false;
                instanceGO = Instantiate(spawnGO, new Vector3(hitPos.position.x, hitPos.position.y + 0.5f, hitPos.position.z), hitPos.rotation);
                tJump.jumpPositions.Add(instanceGO.transform.position);
                StartCoroutine(spawnWait());
            }
        }

        if(anchorCount == 2)
        {
            makeMovement();
        }
    }

    void makeMovement()
    {
        anchorCount++;
        Instantiate(cube, tJump.jumpPositions[0], Quaternion.identity);
    }
    IEnumerator spawnWait()
    {
        yield return new WaitForSeconds(1f);
        waitTime = true;
    }
}
