using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Referenz zum Spieler
    public float distance = 5f;    // Abstand hinter dem Spieler
    public float height = 2f;      // Höhe über dem Spieler
    public float smoothSpeed = 5f; // Wie weich die Kamera folgt

    void LateUpdate()
    {
        if (!player) return;

        // Aktuelle Blickrichtung des Spielers
        Vector3 back = -player.forward;
        Vector3 up = (player.position - Vector3.zero).normalized; // up = von Zentrum zur Oberfläche

        // Zielposition der Kamera berechnen
        Vector3 desiredPosition = player.position + back * distance + up * height;

        // Kamera weich bewegen
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Kamera schaut den Spieler an
        transform.LookAt(player.position, up);
    }
}
