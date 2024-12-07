using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool dustumu = false; // topun yere düşüp düşmediğini kontrol eden bool
    private bool canJump = true; // Zıplama kontrolü
    private float _maxDistance = 0.1f;

    [SerializeField] public Rigidbody _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private Level_Management _levelSc;
    [SerializeField] public float speedup = 5f;
    [SerializeField] public float speedright = 2f;
    [SerializeField] private AudioSource jumpEffect;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Application.targetFrameRate = 300;
    }

    void Update()
    {
        // Top yere düştü mü?
        if (transform.position.y <= 0.13f)
        {
            dustumu = true;
            if (dustumu == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // UI elementlerine tıklanıp tıklanmadığını kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse tıklaması yapıldı!"); // Test için
            // Eğer UI üzerinde tıklama yapılmazsa zıplamayı çalıştır
            MoveBall();
        }

        // Eğer oyun duruyorsa (timeScale == 0) zıplama işlemi engellensin
        if (Time.timeScale == 0 || !canJump)
        {
            return;
        }
    }

    public void MoveBall()
    {
        Debug.Log("MoveBall fonksiyonu çağrıldı!"); // Test için
        if (IsGrounded())
        {
            jumpEffect.Play();
            _rb.AddForce(transform.up * speedup + transform.right * speedright, ForceMode.Impulse);
        }
    }

    public bool IsGrounded()
    {
        if (Physics.BoxCast(_groundCheck.position, _boxSize, -transform.up, transform.rotation, _maxDistance, _groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("floorfinish"))
        {
            _levelSc._continuePanel.SetActive(true);
            speedup = 0f;
            speedright = 0f;
        }
    }

    // Zıplamayı devre dışı bırak
    public void DisableJump()
    {
        canJump = false;
        Debug.Log("Zıplama devre dışı bırakıldı.");
    }

    // Zıplamayı aktif et
    public void EnableJump()
    {
        canJump = true;
        Debug.Log("Zıplama aktif edildi.");
    }
}
