using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SyncMaterialColor : NetworkBehaviour
{
    public readonly SyncVar<Color> color = new SyncVar<Color>();

    void Awake()
    {
        color.OnChange += OnColorChanged;
    }

    private void OnColorChanged(Color prev, Color next, bool asServer)
    {
        GetComponent<MeshRenderer>().material.color = color.Value;
    }
}
