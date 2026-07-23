using UnityEngine;


[RequireComponent(typeof(Animator))]
public class FoodServe : MonoBehaviour
{
    public FoodList foodList;
    public int nextFoodID;
    public float CD;
    public float maxCD; // Must be changable

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CD -= Time.deltaTime;
        if (CD <= 0)
        {
            CD = maxCD;
            ServeFood();
        }
    }

    private void ServeFood()
    {
        animator.Play("JesterServe");
        GameObject foodplate = Instantiate(foodList.foods[nextFoodID].foodPlate, transform.position, Quaternion.identity);

        // Adjustable throw force?
        foodplate.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(3f, 5f), Random.Range(5f, 7.5f)), ForceMode2D.Impulse);

        nextFoodID = Random.Range(0, foodList.foods.Length);
    }
}