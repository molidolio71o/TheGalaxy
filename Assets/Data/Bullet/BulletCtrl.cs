using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TestMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDmgSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDmgSender()
    {
        if (this.damageSender != null) return;
        /*this.damageSender = Transform.FindObjectOfType<DamageSender>();*/
        /*this.damageSender = transform.parent.GetComponent<DamageSender>();*/
        this.damageSender = transform.GetComponentInChildren<DamageSender>(); 
        Debug.Log(transform.name + ": LoadDmgSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
