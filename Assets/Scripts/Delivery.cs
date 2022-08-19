using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 originalColor = new Color32(255, 255, 255, 255);
    SpriteRenderer spriteRenderer;
    private bool hasPackage;
    private GameObject activeCustomer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null) {
            Debug.LogError("SpriteRenderer is null.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
        if (customers == null) {
            Debug.LogError("GameObjects with Customer tag not found.");
        }

        

        if (!hasPackage && other.tag == "Package") {
            Debug.Log("Package picked up.");
            hasPackage = true;

            int randomNumber = Random.Range(0, customers.Length -1);
            activeCustomer = customers[randomNumber];
            activeCustomer.tag = "Active Customer";
            activeCustomer.GetComponent<SpriteRenderer>().color = Color.red;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject);
        }

        if (activeCustomer && hasPackage && other.tag == "Active Customer") {
            Debug.Log("Package Delivered!");
            activeCustomer.GetComponent<SpriteRenderer>().color = originalColor;
            activeCustomer.tag = "Customer";
            spriteRenderer.color = originalColor;
            hasPackage = false;
        }
    }
}
