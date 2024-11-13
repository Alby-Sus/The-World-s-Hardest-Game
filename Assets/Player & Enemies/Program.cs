using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject winCanvas;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        winCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player bị chạm vào quái, quay về vị trí ban đầu!");
            transform.position = startPosition;
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Bạn thắng");
            winCanvas.SetActive(true);
        }
    }
}

