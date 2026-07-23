using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Chyme : MonoBehaviour
{
    public int FoodID;

    [SerializeField] private float timeToDigest;
    [HideInInspector] public float timeLeft;

    void Start()
    {
        timeLeft = timeToDigest;
    }

    void Update()
    {
        transform.localScale = new Vector3(timeLeft / timeToDigest, timeLeft / timeToDigest, 1);
        timeLeft -= Time.deltaTime;
    }

    //Why
    public void Kill()
    {
        Destroy(gameObject);
    }
}