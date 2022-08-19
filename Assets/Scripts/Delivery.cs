using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
    private bool hasPackage;
    private GameObject activeCustomer;
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
        //Color originalColor = null;
        if (customers == null) {
            Debug.LogError("GameObjects with Customer tag not found.");
        }

        

        if (!hasPackage && other.tag == "Package") {
            Debug.Log("Package picked up.");
            hasPackage = true;

            int randomNumber = Random.Range(0, customers.Length -1);
            Debug.Log("customers.Length: " + customers.Length);
            Debug.Log(randomNumber);
            activeCustomer = customers[randomNumber];
            activeCustomer.tag = "Active Customer";
            activeCustomer.GetComponent<SpriteRenderer>().color = Color.red;

            Destroy(other.gameObject);
        }

        if (activeCustomer && hasPackage && other.tag == "Active Customer") {
            Debug.Log("Package Delivered!");
            activeCustomer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            activeCustomer.tag = "Customer";
            hasPackage = false;
        }
    }
}
