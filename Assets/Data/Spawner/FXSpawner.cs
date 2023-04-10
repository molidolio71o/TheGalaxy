using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string smoke1 = "Smoke_1";
    public static string impact1 = "Impact_1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        FXSpawner.instance = this;
    }


}
