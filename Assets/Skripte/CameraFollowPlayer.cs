// 27.08.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player; // Referenz zum Spieler
    public Vector3 offset = new Vector3(0, 5, -10); // Offset der Kamera relativ zum Spieler
    public float followSpeed = 5f; // Geschwindigkeit, mit der die Kamera dem Spieler folgt
    public float rotationSpeed = 5f; // Geschwindigkeit, mit der die Kamera rotiert

    void LateUpdate()
    {
        if (player == null)
            return;

        // Zielposition der Kamera basierend auf dem Spieler und dem Offset
        Vector3 targetPosition = player.position - player.TransformDirection(player.forward);

        // Kamera sanft zur Zielposition bewegen
        //transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.position = targetPosition;
        // Kamera sanft in Richtung des Spielers rotieren
        Quaternion targetRotation = Quaternion.LookRotation(player.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
}
