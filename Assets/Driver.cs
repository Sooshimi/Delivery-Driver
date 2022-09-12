using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float slowSpeed = 8;
    [SerializeField] float boostSpeed = 20;

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("BUMP");
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
