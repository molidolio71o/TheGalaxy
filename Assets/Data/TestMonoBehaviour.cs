using UnityEngine;

public class TestMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }

    protected virtual void OnEnable()
    {

    }

}
