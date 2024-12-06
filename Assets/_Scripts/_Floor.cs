using UnityEngine;
public class _Floor : MonoBehaviour
{

    [Header("Zemin")]
    [SerializeField]
    private GameObject zemin;

    [Header("Pozisyonlar")]
    [SerializeField]
    private Vector3 startpos1;
    [SerializeField]
    private Vector3 startpos2;

    // Rigidbody
    private Rigidbody rb;

    [Header("Speed")]
    [SerializeField]
    private float speed;

    [Header("ZeminPrefab")]
    [SerializeField]
    private GameObject zeminprefab;

    public bool tagchanger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Rigidbody'nin baþlangýçta kinematic olmasýný saðlamak
        rb.isKinematic = true;
    }

    private void Start()
    {
        startpos1 = zemin.transform.position;
    }

    private void FixedUpdate()
    {
        FloorMove();
    }

    private void FloorMove()
    {
        // zemin hareketi kodu 
        zemin.transform.position = Vector3.MoveTowards(zemin.transform.position, startpos1, speed * Time.deltaTime);

        if (zemin.transform.position == startpos1)
        {
            // Pozisyonlarý yer deðiþtirerek zemin hareketini sürdürme
            Vector3 temp = startpos1;
            startpos1 = startpos2;
            startpos2 = temp;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            tagchanger = true;
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
