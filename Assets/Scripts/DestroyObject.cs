// Digx
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    [SerializeField] private float destroyTimeDelay = 0.0f;
    [SerializeField] private bool destroyOnAwake = false;

    public void Awake() {
        if (destroyOnAwake) _Destory();
    }

    public void _Destory() {
        Destroy(gameObject, destroyTimeDelay);
    }
}
