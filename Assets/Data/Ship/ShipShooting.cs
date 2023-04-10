using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    /*[SerializeField] protected Transform bulletPrefab;*/

    void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;

        this.shootTimer = 0;


        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        /*Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);*/
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        Debug.Log("Shooting");
        
    }

    /*public virtual void OnMouseDown()
    {
        Debug.Log("bam");
        this.IsShooting();
    }*/
    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
