using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{
    public Transform playerTransform;

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.Log("Your rigidbody is somehow not initialized");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(xInput, yInput).normalized;
        rb.linearVelocity = direction * speed;
    }

    public void LoadData(TransformSaver data)
    {
        this.transform.position = data.playerTransform;
    }

    public void SaveData(ref TransformSaver data)
    {
        data.playerTransform = this.transform.position;
    }
}
