using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    [SerializeField] float _moveSpeed = 15f;
    [SerializeField] float _steerSpeed = 75f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        CalculateMovement();
    }

    private void CalculateMovement() {
        float steerAmount = Input.GetAxis("Horizontal") * _steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
