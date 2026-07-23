using System;
using System.Collections.Generic;
using UnityEngine;

public class StomachLogic : MonoBehaviour
{
    [SerializeField] private FoodList foodList;

    [SerializeField] private Vector2 chymeDropPos;
    public static Action<int> OnFoodConsume;
    private List<Chyme> FoodInStomachs = new();
    private bool isPoisoning = false;

    void OnEnable()
    {
        OnFoodConsume += ConsumingFood;
    }

    void OnDisable()
    {
        OnFoodConsume -= ConsumingFood;
    }

    void Update()
    {
        // Iterate check food here
        for (int i = 0; i < FoodInStomachs.Count; i++)
        {
            if (FoodInStomachs[i].timeLeft <= 0)
            {
                // UI de-display
                FoodInStomachs[i].Kill();
                FoodInStomachs.RemoveAt(i);
                IsFoodPoisoning();
            }
        }
    }

    private void ConsumingFood(int ID)
    {
        Food food = foodList.foods[ID];
        FoodInStomachs.Add(Instantiate(food.chyme, chymeDropPos, Quaternion.identity).GetComponent<Chyme>());

        // UI Display

        IsFoodPoisoning();
    }


    // Run on OnFoodConsume and Food exit
    private void IsFoodPoisoning()
    {
        // Check List Chyme ID for invalid combination
    }
}
