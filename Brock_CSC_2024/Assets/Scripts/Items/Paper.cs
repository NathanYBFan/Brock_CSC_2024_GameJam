using UnityEngine;

public class Paper : Item
{
    private void Start()
    {
        TaskManager._Instance.PaperToCleanUp.Add(this);
    }

    public override void Use(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "GarbageCan":
                PlayerStatsManager._Instance.IncreasePoints(50);
                break;
            case "Sink":
                PlayerStatsManager._Instance.IncreasePoints(-100);
                break;
            case "Shelf":
                PlayerStatsManager._Instance.IncreasePoints(100);
                break;
        }
        TaskManager._Instance.CleanedUpPaper(this);
    }
}
