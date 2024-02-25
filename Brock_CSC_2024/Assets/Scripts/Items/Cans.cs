using UnityEngine;

public class Cans : Item
{
    public override void Use(RaycastHit hit)
    {
        TaskManager._Instance.CleanedUpCan(this);
    }

    void Start()
    {
        TaskManager._Instance.EmptyCans.Add(this);
    }

}
