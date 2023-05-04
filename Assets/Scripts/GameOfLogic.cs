using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOfLogic : MonoBehaviour {
    [SerializeField] private GameObject ball;
    // [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Material[] materials;

    private void OnTriggerEnter(Collider other) {
        Destroy(ball);
    }

    private void Logic(GameObject hittedBall) {
        if (hittedBall.name == ball.name) {
            // counter.text = "hit";
            Destroy(hittedBall);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Logic(hit.collider.gameObject);
            }
        }
    }
}
