using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : TestMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;
    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
