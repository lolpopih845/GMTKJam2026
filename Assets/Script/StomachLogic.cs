using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StomachLogic : MonoBehaviour
{
    [Header("UIRef")]
    [SerializeField] private GameObject foodCDIcon;
    [SerializeField] private GameObject iconBar;

    [Header("Field")]
    [SerializeField] private FoodList foodList;
    [SerializeField] private Vector2 chymeDropPos;
    private List<Chyme> FoodInStomachs = new();
    private bool isPoisoning = false;

    void OnEnable()
    {
        EventBoi.OnFoodConsume += ConsumingFood;
    }

    void OnDisable()
    {
        EventBoi.OnFoodConsume -= ConsumingFood;
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
        GameObject UIObject = Instantiate(foodCDIcon, iconBar.transform);
        UIObject.GetComponentInChildren<Image>().sprite = food.foodSprite;
        FoodInStomachs.Add(Instantiate(food.chyme, chymeDropPos, Quaternion.identity).GetComponent<Chyme>().InitWithUI(UIObject));

        // UI Display

        IsFoodPoisoning();
    }


    // Run on OnFoodConsume and Food exit
    private void IsFoodPoisoning()
    {
        // Check List Chyme ID for invalid combination
    }
}
