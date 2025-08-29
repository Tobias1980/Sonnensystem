// 28.08.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class FixedFollowCamera : MonoBehaviour
{
    public Transform player; // Referenz auf den Spieler
    public Vector3 offset = new Vector3(0, 5, -10); // Offset der Kamera relativ zum Spieler

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Kein Spieler zugewiesen!");
            return;
        }

        // Position der Kamera direkt an die Spielerposition plus Offset setzen
        transform.position = player.position;

        // Kamera zeigt in die gleiche Richtung wie der Spieler
        transform.rotation = player.rotation;
    }
}
