using UnityEngine;

public class Cans : Item
{
    void Start()
    {
        TaskManager._Instance.EmptyCans.Add(this);
    }
    
    public override void Use(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "GarbageCan":
                PlayerStatsManager._Instance.IncreasePoints(100);
                break;
            case "Sink":
                PlayerStatsManager._Instance.IncreasePoints(50);
                break;
        }
        TaskManager._Instance.CleanedUpCan(this);
    }
}
