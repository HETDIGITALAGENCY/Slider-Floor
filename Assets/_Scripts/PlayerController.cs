using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    bool dustumu = false; // topun yere dusup dusmedigini kontrol eden bool
    private float _maxDistance=0.1f;

    [SerializeField] public Rigidbody _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private Level_Management _levelSc;
    [SerializeField] public float speedup = 5f;
    [SerializeField] public float speedright = 2f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int rayLenght;
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
        MoveBall();
    }
   
    public void MoveBall()
    {      
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {    
              jumpEffect.Play();
            _rb.AddForce(transform.up * speedup + transform.right * speedright, ForceMode.Impulse);
        }
        if (transform.position.y <= 0.13f)
        {
            dustumu = true;
            if (dustumu == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
    public bool IsGrounded()
    {
        if(Physics.BoxCast(_groundCheck.position, _boxSize , -transform.up, transform.rotation,_maxDistance,_groundLayer))
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
    

 



}
