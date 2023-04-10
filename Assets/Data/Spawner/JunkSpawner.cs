using UnityEngine;

public class JunkSpawner : Spawner
{
    protected static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }

    public static string Asteroid = "FireBall 1";
    /*    public static string bulletTwo = "Bullet_2";*/

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("Only 1 JunkSpawner allow to exist");
        JunkSpawner.instance = this;
    }
}
