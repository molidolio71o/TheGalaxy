using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JunkSpawnRandom : TestMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkCtrl;
    [SerializeField] protected float randomDelay = 2f;
    [SerializeField] protected float ramdomTimer = 0f;
    [SerializeField] protected float randomLimit = 20f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJubkSpawner" + gameObject);
    }

    /*protected override void Start()
    {
        this.JunkSpawning();
    }*/

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.ramdomTimer += Time.fixedDeltaTime;
        if (this.ramdomTimer < this.randomDelay) return;
        this.ramdomTimer = 0f;

        Transform randPoint = this.junkCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkCtrl.JunkSpawner.RandomPrefab();
        Transform ojb = this.junkCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        ojb.gameObject.SetActive(true);

        /*Invoke(nameof(this.JunkSpawning), 1f);*/
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkCtrl.JunkSpawner.SpawnedCout;
        return currentJunk >= this.randomLimit;
    }
}
