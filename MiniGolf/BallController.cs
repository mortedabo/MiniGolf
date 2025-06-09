using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Go")]
    public float forceMultiplier = 10f;
    private Vector3 direction;
    private float force;

    private bool isCharging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("На объекте нет Rigidbody! Добавь компонент Rigidbody.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            force = 0f;
        }

        if (isCharging)
        {
            force += Time.deltaTime * forceMultiplier;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 dir = (hit.point - transform.position).normalized;
                rb.AddForce(dir * force, ForceMode.Impulse);
            }

            force = 0f;
        }
    }
   
}