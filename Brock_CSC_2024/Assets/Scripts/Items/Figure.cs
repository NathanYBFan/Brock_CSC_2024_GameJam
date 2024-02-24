using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : Item
{
    public override void Use(RaycastHit hit)
    {
        TaskManager._Instance.TaskComplete(0);
    }
}
