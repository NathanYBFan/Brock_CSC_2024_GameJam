using UnityEngine;
public class Dishes : Interactable
{
    [SerializeField]
    private GameObject rootObject;
    private void Start()
    {
        TaskManager._Instance.DishesToCleanUp.Add(this.gameObject);
    }

    public override void ApplyEffect()
    {
        return;
    }

    public override void InteractedWith()
    {
        PlayerStatsManager._Instance.IncreasePoints(100);
        TaskManager._Instance.CleanedUpDish(this.gameObject);
        Destroy(rootObject);
    }
}
