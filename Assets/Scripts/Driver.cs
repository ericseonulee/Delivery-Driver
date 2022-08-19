using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //[SerializeField]
    float _moveSpeed = 20f;
    //[SerializeField]
    float _steerSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement() {
        float steerAmount = Input.GetAxis("Horizontal") * _steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        // if (transform.position.y >= 4.7f) {
        //     transform.position = new Vector3(transform.position.x, 4.7f, transform.position.z);
        // }
        // else if (transform.position.y <= -4.7f) {
        //     transform.position = new Vector3(transform.position.x, -4.7f, transform.position.z);
        // }

        // if (transform.position.x >= 9.5f) {
        //     transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        // }
        // else if (transform.position.x <= -9.5f) {
        //     transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        // }
    }
}
