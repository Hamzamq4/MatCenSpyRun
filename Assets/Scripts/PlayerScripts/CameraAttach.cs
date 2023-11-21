using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attached to the camera, and serves as a smooth following 
/// camera that follows the player and changes position depending on which 
/// terrain the player is on.
/// </summary>

public class CameraAttach : MonoBehaviour
{

    [SerializeField] private Vector3 offset = new Vector3(0, 20, -10);
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    public Camera cam;

    private LayerMask schoolTerrainLayerMask;

    private Vector3 originalOffset;
    private Vector3 schoolTerrainOffset = new Vector3(0, 3, -3);

    private void Start()
    {
        originalOffset = offset;
        schoolTerrainLayerMask = LayerMask.GetMask("SchoolTerrain");
    }

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
        HandleTerrainOffset();
    }

    //HandleTranslation handles the positioning of the camera in relation to the position of the player in world space, and the smooth interpolation of the camera. 

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    //HandleRotation handles the rotation of the camera in relation to the position of the player in world space, and the smooth interpolation of the camera. 
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, (Vector3.up));
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    //HandleTerrainOffset detects the upcoming terrain layermask and changes the camera offset to the values stated in "schoolTerrainOffset", and reverts back when it turns back to the original terrain.
    private void HandleTerrainOffset()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, schoolTerrainLayerMask))
        {
            offset = schoolTerrainOffset;
        }
        else
        {
            offset = originalOffset;
        }
    }
}
