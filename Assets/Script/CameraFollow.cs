using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public float timeOffset = 0.2f; // Vitesse de lissage du
    public Vector3 posOffset; // Décalage de la caméra par rapport au joueur
    private Vector3 velocity;


    void Awake()
    {
        transform.position = player.position + posOffset; // Position initiale de la caméra
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
