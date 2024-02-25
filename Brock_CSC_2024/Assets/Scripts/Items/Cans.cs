using UnityEngine;

public class Cans : Item
{
    public override void Use(RaycastHit hit)
    {
        PlayerStatsManager._Instance.IncreasePoints(100);
        TaskManager._Instance.CleanedUpCan(this);
    }

    void Start()
    {
        TaskManager._Instance.EmptyCans.Add(this);
    }

}
