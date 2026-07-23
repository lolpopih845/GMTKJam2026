using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class FoodPlate : MonoBehaviour
{
    public int foodID;

    [Header("Drag")]
    public float followSpeed = 20f;

    private Rigidbody2D rb;
    private Camera cam;

    private bool dragging;
    private Vector2 targetPosition;
    private Vector2 lastMouseWorld;
    private Vector2 throwVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Invoke(nameof(EnableHitbox), 1.5f);
    }

    private void Update()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        targetPosition = cam.ScreenToWorldPoint(mouseScreen);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryBeginDrag();
        }

        if (dragging)
        {
            throwVelocity = (targetPosition - lastMouseWorld) / Time.deltaTime;
            lastMouseWorld = targetPosition;

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                EndDrag();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!dragging)
            return;

        Vector2 force = (targetPosition - rb.position) * followSpeed;
        rb.linearVelocity = force;
    }

    void TryBeginDrag()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider == null)
            return;

        if (hit.collider.gameObject != gameObject)
            return;

        dragging = true;
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;

        lastMouseWorld = targetPosition;
    }

    void EndDrag()
    {
        dragging = false;

        rb.gravityScale = 1;
        rb.linearVelocity = throwVelocity * 0.35f;
    }

    private void EnableHitbox()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}