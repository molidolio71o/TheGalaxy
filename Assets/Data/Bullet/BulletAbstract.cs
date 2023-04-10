using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : TestMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] private BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReciever();
    }

    protected virtual void LoadDamageReciever()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadDamageReciever", gameObject);
    }
}
