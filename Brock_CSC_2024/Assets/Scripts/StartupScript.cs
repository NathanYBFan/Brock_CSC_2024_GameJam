using UnityEngine;

public class StartupScript : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        Destroy(this);
    }
}
