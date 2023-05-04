using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall: MonoBehaviour {
    public float speed = 0.04f;
    private Vector3 direction = new Vector3(0, -1, 0);

    void Start() {
        
    }

    void FixedUpdate() {
        transform.Translate(direction.normalized * speed);
    }
}
