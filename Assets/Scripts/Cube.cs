using System;
using UnityEngine;

public class Cube : MonoBehaviour {

    private float speed;
    private float distance;

    private Transform cubeTransform;
    private Vector3 startPosition;

    private void Start() {
        cubeTransform = transform;
        startPosition = cubeTransform.position;
    }

    public void Move(float speed, float distance) {
        this.speed = speed;
        this.distance = distance;
    }

    private void Update() {
        cubeTransform.position += Vector3.forward * (speed * Time.deltaTime);

        if ((cubeTransform.position - startPosition).sqrMagnitude >= distance * distance) {
            Destroy(gameObject);
        }
    }
}