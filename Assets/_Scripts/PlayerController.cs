using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    

   void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

   
    void Update()
    {
        MoveBall();
    }
   
    public void MoveBall()
    {  
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && IsGrounded()) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                {
                   _rb.AddForce(transform.up * speedup + transform.right * speedright, ForceMode.Impulse);
                   hit.collider.GetComponent<Collider>();
                }
            }
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
    private bool IsGrounded()
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
