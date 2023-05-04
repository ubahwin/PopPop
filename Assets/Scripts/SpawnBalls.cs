using System.Linq;
using UnityEngine;

public class SpawnBalls : MonoBehaviour {
    public GameObject ball;
    public Material[] Materials;

    private const float BALL_Y_START_POSITION = 12f;
    private const float BALL_X_START_POSITION = -2.1f;
    private const float BALL_X_OFFSET = 1.4f;
    private const float BALL_Y_DEVIATION = 0.1f;

    private readonly float[] _ballsPositions;

    public SpawnBalls() {
        _ballsPositions = new float[4];
        
        for (int i = 0; i < _ballsPositions.Length; i++) {
            _ballsPositions[i] = BALL_X_START_POSITION + i * BALL_X_OFFSET;
        }
    }

    private int[] GetRandomPositions(int count) {
        int[] rand = Enumerable.Range(0, 4).ToArray();
        rand = rand.OrderBy(x => Random.Range(0, 4)).ToArray();
        return rand.Take(count).ToArray();
    }

    private void SpawnBall(int position) {
        if (position > _ballsPositions.Length - 1) {
            throw new System.Exception("Invalid position");
        }

        float yDeviation = Random.Range(-BALL_Y_DEVIATION, BALL_Y_DEVIATION);
        int material = Random.Range(0, 4);

        ball.transform.position = new Vector3(_ballsPositions[position], BALL_Y_START_POSITION + yDeviation, 0);
        SetMaterial(material);
        Instantiate(ball);
    }

    private void SpawnBallsRow() {
        int count = Random.Range(0, 5);
        int[] positions = GetRandomPositions(count);

        for (int i = 0; i < positions.Length; i++) {
            SpawnBall(positions[i]);
        }
    }
    
    private void SetMaterial(int materialIndex) {
        ball.GetComponent<Renderer>().material = Materials[materialIndex];
    }

    public void MainSpawnBalls() {
        InvokeRepeating(nameof(SpawnBallsRow), 0, 0.6f);
    }

    public void StopSpawn() {
        CancelInvoke();
    }
}
