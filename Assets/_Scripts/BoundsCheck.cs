using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;

    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;
    void Awake() {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UnityEngine.Vector3 pos = transform.position;

        if (pos.x > camWidth - radius) {
            pos.x = camWidth - radius;
        }

        if (pos.x < -camWidth + radius) {
            pos.x = -camWidth + radius;
        }

        if (pos.y > camHeight - radius) {
            pos.y = camHeight - radius;
        }

        if (pos.y < -camHeight + radius) {
            pos.y = -camHeight + radius;
        }

        transform.position = pos;
    }

    void OnDrawGizmos() {
        if (!Application.isPlaying) return;
        UnityEngine.Vector3 boundSize = new UnityEngine.Vector3(camWidth*2, camHeight*2, 0.1f);
        Gizmos.DrawWireCube(UnityEngine.Vector3.zero, boundSize);
    }
}
