using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Cube cubePrefab;
    [SerializeField] private float spawningInterval = 1;
    [SerializeField] private float cubeSpeed = 2;
    [SerializeField] private float distanceToMove = 10;
    [Space(10)] [SerializeField] private Transform mostRightCubePosition;


    private void Start() {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning() {

        while (true) {
            var cube = Instantiate(cubePrefab);
            cube.transform.position = getStartPosition();
            cube.Move(cubeSpeed, distanceToMove);

            yield return new WaitForSeconds(spawningInterval);
        }
    }

    private Vector3 getStartPosition() {
        var x = Mathf.Lerp(-mostRightCubePosition.position.x, mostRightCubePosition.position.x, Random.value);
        return new Vector3(x, mostRightCubePosition.position.y, mostRightCubePosition.position.z);
    }
}