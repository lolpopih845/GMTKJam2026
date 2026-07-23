using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Chyme : MonoBehaviour
{
    private GameObject foodCDIconGO;
    private TMP_Text cooldown_text;

    [Header("Field")]
    public int FoodID;
    [SerializeField] private float timeToDigest;
    [HideInInspector] public float timeLeft;

    public Chyme InitWithUI(GameObject foodCDIconGO)
    {
        this.foodCDIconGO = foodCDIconGO;
        timeLeft = timeToDigest;
        cooldown_text = foodCDIconGO.GetComponentInChildren<TMP_Text>();
        return this;
    }

    void Update()
    {
        transform.localScale = new Vector3(timeLeft / timeToDigest, timeLeft / timeToDigest, 1);
        timeLeft -= Time.deltaTime;
        cooldown_text.text = $"{(int)timeLeft}.{(int)(timeLeft * 1000 % 1000)}";
    }

    public void Kill()
    {
        Destroy(foodCDIconGO);
        Destroy(gameObject);
    }
}