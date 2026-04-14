using UnityEngine;
using System.Collections.Generic;

public class TornadoPull : MonoBehaviour
{
    public Transform centerPoint; // Un objeto vacío que se mueve arriba/abajo
    public float pullForce = 10f;
    public float rotationSpeed = 50f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 1. Dirección hacia el centro
            Vector3 direction = centerPoint.position - other.transform.position;
            float distance = direction.magnitude;

            // 2. Fuerza de atracción
            rb.AddForce(direction.normalized * pullForce / distance, ForceMode.Acceleration);

            // 3. Efecto de rotación (fuerza tangencial)
            Vector3 pullRotation = Vector3.Cross(direction, Vector3.up);
            rb.AddForce(pullRotation * rotationSpeed, ForceMode.Acceleration);
        }
    }
}