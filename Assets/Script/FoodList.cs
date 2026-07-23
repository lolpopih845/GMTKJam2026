using UnityEngine;

[System.Serializable]
public struct Food
{
    public GameObject foodPlate;
    public GameObject chyme;
    public Sprite foodSprite;
}

[CreateAssetMenu(menuName = "Data/FoodList")]
public class FoodList : ScriptableObject
{
    public Food[] foods;
}