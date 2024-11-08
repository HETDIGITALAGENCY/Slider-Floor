using UnityEngine;

public class F_M_Left : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Ayarlar")]
    [SerializeField] private float speed; // Zeminin hareket hýzý
    [SerializeField] private float distance ; // Zeminin bir yönde gideceði maksimum mesafe
    private float currentDistance = 0f; // Þu anki mesafe
    private int direction = 1; // Hareket yönü (1 saða, -1 sola)

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Baþlangýçta kinematic olarak ayarlanmasý
    }

    private void FixedUpdate()
    {
        FloorMoveLeft();
    }

    private void FloorMoveLeft()
    {
        // Zeminin hareket miktarýný hesapla
        float moveAmount = speed * Time.deltaTime;

        // Yeni mesafeyi kontrol et ve hareket miktarýný ayarla
        if (currentDistance + moveAmount > distance)
        {
            moveAmount = distance - currentDistance; // Kalan mesafe kadar hareket et
            direction *= -1; // Yönü ters çevir
        }

        // Zemini hareket ettir ve mevcut mesafeyi güncelle
        transform.position += Vector3.back * direction * moveAmount;
        currentDistance += moveAmount;

        // Eðer yön deðiþtiyse, mesafeyi sýfýrla
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
