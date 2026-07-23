using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StomachTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FoodPlate food))
        {
            StomachLogic.OnFoodConsume?.Invoke(food.foodID);
            Destroy(collision.gameObject);
        }
    }
}