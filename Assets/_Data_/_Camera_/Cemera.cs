using Cinemachine;
using UnityEngine;

public class Cemera : Mono
{
    [SerializeField] protected Camera mainCamera;

    public Camera MainCamera => mainCamera;

    [SerializeField] protected CinemachineVirtualCamera virtualCamera;

    public CinemachineVirtualCamera VirtualCamera => virtualCamera;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
        LoadVirtualCamera();
    }

    protected void LoadCamera()
    {
        if(mainCamera != null) return;

        mainCamera = GetComponentInChildren<Camera>();
    }

    protected void LoadVirtualCamera()
    {
        if(virtualCamera != null) return;

        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }
}