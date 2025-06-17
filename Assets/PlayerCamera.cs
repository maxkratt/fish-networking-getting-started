using FishNet.Object;
using UnityEngine;

// This script will be a NetworkBehaviour so that we can use the 
// OnStartClient override.
public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private Camera cameraPrefab;
    [SerializeField] private Transform cameraHolder;

    // This method will run on the client once this object is spawned.
    public override void OnStartClient()
    {
        // Since this will run on all clients that this object spawns for
        // we need to only instantiate the camera for the object we own.
        if (IsOwner)
            Instantiate(cameraPrefab, cameraHolder.position, cameraHolder.rotation, cameraHolder);
    }
}