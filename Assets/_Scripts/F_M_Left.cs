using UnityEngine;

public class F_M_Left : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Ayarlar")]
    [SerializeField] private float speed; // Zeminin hareket h�z�
    [SerializeField] private float distance ; // Zeminin bir y�nde gidece�i maksimum mesafe
    private float currentDistance = 0f; // �u anki mesafe
    private int direction = 1; // Hareket y�n� (1 sa�a, -1 sola)

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Ba�lang��ta kinematic olarak ayarlanmas�
    }

    private void FixedUpdate()
    {
        FloorMoveLeft();
    }

    private void FloorMoveLeft()
    {
        // Zeminin hareket miktar�n� hesapla
        float moveAmount = speed * Time.deltaTime;

        // Yeni mesafeyi kontrol et ve hareket miktar�n� ayarla
        if (currentDistance + moveAmount > distance)
        {
            moveAmount = distance - currentDistance; // Kalan mesafe kadar hareket et
            direction *= -1; // Y�n� ters �evir
        }

        // Zemini hareket ettir ve mevcut mesafeyi g�ncelle
        transform.position += Vector3.back * direction * moveAmount;
        currentDistance += moveAmount;

        // E�er y�n de�i�tiyse, mesafeyi s�f�rla
        if (moveAmount < speed * Time.deltaTime)
        {
            currentDistance = 0f;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            speed = 0f;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            Destroy(gameObject, 5f);
        }
    }
}
