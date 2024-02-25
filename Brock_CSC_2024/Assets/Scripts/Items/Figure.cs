using UnityEngine;

public class Figure : Item
{
    public override void Use(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "GarbageCan":
                PlayerStatsManager._Instance.IncreasePoints(-100);
                break;
            case "Sink":
                PlayerStatsManager._Instance.IncreasePoints(-100);
                break;
            case "Shelf":
                PlayerStatsManager._Instance.IncreasePoints(1000);
                break;
        }
        TaskManager._Instance.TaskComplete(0);
    }
}
