using UnityEngine;

public class BeeScript : MonoBehaviour
{
    private Vector3 Min = new Vector3(-20, 0, -20);
    private Vector3 Max = new Vector3(20, 20, 20);

    Vector3 target;
    Vector3 direction;

    Rigidbody rb;

    Collider[] bees;

    public float speed = 1;

    void Start()
    {
        target = GetNewPosition();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        direction = target - transform.position;

        if (direction.magnitude < 5)
        {
            target = GetNewPosition();
        }
        rb.AddForce(direction * speed, ForceMode.Acceleration);
        bees = Physics.OverlapSphere(transform.position, 10, 1 << 9);
        for (int i = 1; i < bees.Length; i++)
        {
            rb.AddForce((transform.position - bees[i].transform.position) * 10);
        }
    }

    Vector3 GetNewPosition()
    {
        float x, y, z;
        x = Random.Range(Min.x, Max.x);
        y = Random.Range(Min.y, Max.y);
        z = Random.Range(Min.z, Max.z);

        return new Vector3(x, y, z);
    }
}
