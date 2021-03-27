//using Mirror;
//using System;
//using UnityEngine;

//public enum PlayerMode
//{
//    Local,
//    Remote
//}

//[RequireComponent(typeof(PlayerSystemInterface), typeof(Health))]
//public class GamePlayer : NetworkBehaviour, ICollector 
//{
//    public PlayerSystemInterface Interface;
//    public Health Health;

//    public PlayerController LocalController;
//    public CameraSystemInterface CameraInterface;

//    public Rigidbody rBody;
//    public Collider col;

//    private void Awake()
//    {
//        Health.OnDamaged += OnPlayerDamaged;
//        Health.OnHealed += OnPlayerHealed;
//        Health.OnRespawn += OnPlayerRespawn;
//    }
//    private void Start()
//    {
//        bool isLocal = isLocalPlayer;

//        if (isLocal)
//        {
//            LocalController.SetMode(PlayerMode.Local);
//            CameraInterface.Target.Camera.SetTarget(LocalController.innerHead);
//            CameraInterface.Target.Camera.SetLerp(1.0f);
//            col.enabled = true;
//            col.isTrigger = false;
//        }
//        else
//        {
//            LocalController.SetMode(PlayerMode.Remote);

//            GameObject.DestroyImmediate(rBody);
//            col.enabled = true;
//            col.isTrigger = true;
//        }
//    }

//    public IHealth GetHealth()
//    {
//        return Health;
//    }

//    private void OnPlayerRespawn()
//    {
//        throw new NotImplementedException();
//    }

//    private void OnPlayerHealed()
//    {
//        throw new NotImplementedException();
//    }

//    private void OnPlayerDamaged()
//    {
//        throw new NotImplementedException();
//    }

//    private void Reset()
//    {
//        Interface = GetComponent<PlayerSystemInterface>();
//    }

//    public bool TryCollect(Collectable target)
//    {


//        return true;
//    }
//}