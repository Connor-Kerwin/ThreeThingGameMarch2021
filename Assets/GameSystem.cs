using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSystemConstants
{
    public const int GAME_SYSTEM_EXECUTION_ORDER = -1024;
    public const int GAME_INTERFACE_EXECUTION_ORDER = -1023;
}

[DefaultExecutionOrder(GameSystemConstants.GAME_SYSTEM_EXECUTION_ORDER)]
public class GameSystem<SystemType> : MonoBehaviour
    where SystemType : GameSystem<SystemType>
{
    public static SystemType Instance { get; private set; }

    protected virtual void Awake()
    {
        Instance = this as SystemType;
    }
}

public abstract class TargetInterface<TargetType> : MonoBehaviour
{
    public TargetType Target { get; protected set; }

    protected abstract TargetType GetTarget();
}

[DefaultExecutionOrder(GameSystemConstants.GAME_INTERFACE_EXECUTION_ORDER)]
public abstract class GameSystemInterface<SystemType> : TargetInterface<SystemType>
{
    protected virtual void Awake()
    {
        Target = GetTarget();
    }
}
