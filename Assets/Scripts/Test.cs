using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform test;
    private Rigidbody2D[] _rbs;

    private void Reset()
    {
        test = transform;
    }

    private void Awake()
    {
        _rbs = test.GetComponentsInChildren<Rigidbody2D>();
    }

    private void Start()
    {
        foreach (Rigidbody2D rb in _rbs)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 50), "Drop"))
        {
            foreach (Rigidbody2D rb in _rbs)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
