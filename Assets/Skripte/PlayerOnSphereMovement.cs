// 27.08.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOnSphereMovement : MonoBehaviour
{
   
    public GameObject sphere; // Referenz zur Kugel
    public float moveSpeed = 5f; // Bewegungsgeschwindigkeit
    public float rotationSpeed = 100f; // Rotationsgeschwindigkeit
    public float dampingFactor = 0.95f; // D�mpfungsfaktor f�r Restbewegung

    private Rigidbody rb;
    private Vector2 moveInput; // Speichert die Eingaben des Spielers
    private float sphereRadius; // Radius der Kugel
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Schwerkraft deaktivieren, da wir sie selbst simulieren

        SphereCollider sphereCollider = sphere.GetComponent<SphereCollider>();
        sphereRadius = sphereCollider.radius * sphere.transform.localScale.x;
    }

    void FixedUpdate()
    {
        // Spieler zur Kugelmitte ziehen (Gravitation simulieren)
        Vector3 directionToCenter = (sphere.transform.position - transform.position).normalized;

        // Spieler auf der Kugeloberfl�che fixieren
       
        Vector3 targetPosition = sphere.transform.position - directionToCenter * sphereRadius;
        rb.MovePosition(targetPosition);

        // Spieler auf der Kugel ausrichten
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -directionToCenter) * transform.rotation;
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed));

        // Bewegung basierend auf Input
        if (moveInput != Vector2.zero) // Nur bewegen, wenn Eingabe vorhanden ist
        {
            Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        // Restbewegung d�mpfen
        rb.linearVelocity *= dampingFactor;
        rb.angularVelocity *= dampingFactor;
    }

    // Diese Methode wird vom Input System aufgerufen
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Wenn die Eingabe gestoppt wird, moveInput auf (0, 0) setzen
        if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }
}