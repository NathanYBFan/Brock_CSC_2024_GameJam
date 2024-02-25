using UnityEngine;

public class Dishes : Item
{
    private void Start()
    {
        TaskManager._Instance.DishesToCleanUp.Add(this);
    }

    public override void Use(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "GarbageCan":
                PlayerStatsManager._Instance.IncreasePoints(10);
                break;
            case "Sink":
                PlayerStatsManager._Instance.IncreasePoints(100);
                break;
            case "Shelf":
                PlayerStatsManager._Instance.IncreasePoints(-100);
                break;
        }
        TaskManager._Instance.CleanedUpDish(this);
    }
}
