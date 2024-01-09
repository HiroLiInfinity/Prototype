using Cinemachine;
using UnityEngine;

public class FollowCharacter : Mono
{
    [Header("Follow Charater")]
    [SerializeField] protected Transform model;
    [SerializeField] protected CinemachineVirtualCamera virtualCamera;

    protected override void Start()
    {
        base.Start();
        model = GameController.Instance.Player.Model;
        virtualCamera = GameController.Instance.Cemera.VirtualCamera;
        virtualCamera.Follow = model;
    }
}