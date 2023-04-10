using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTimes
{
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
