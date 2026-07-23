using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private TMP_Text timer_text;
    [SerializeField] private TMP_Text food_text;

    [Header("Field")]
    public static GameState I;
    [SerializeField] private float maxTimer = 300;
    public float timer;

    private int foodScore = 0;
    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        timer = maxTimer;
        foodScore = 0;
    }

    void OnEnable()
    {
        EventBoi.OnFoodConsume += IncreaseScore;
    }

    void OnDisable()
    {
        EventBoi.OnFoodConsume -= IncreaseScore;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        DisplayTime();
    }

    private void IncreaseScore(int _)
    {
        foodScore++;
        food_text.text = $"Score : {foodScore}";
    }

    private void DisplayTime()
    {
        if (timer < 0) timer = 0;

        int hours = (int)(timer / 3600);
        int minutes = (int)(timer % 3600 / 60);
        int seconds = (int)(timer % 60);
        int milliseconds = (int)(timer * 1000 % 1000);

        timer_text.text = string.Format("{0:00}:{1:00}:{2:00}.{3:03}", hours, minutes, seconds, milliseconds);
    }
}