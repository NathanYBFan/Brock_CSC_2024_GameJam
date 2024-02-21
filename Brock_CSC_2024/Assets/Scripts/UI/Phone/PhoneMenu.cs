using System.Collections;
using TMPro;
using UnityEngine;

public class PhoneMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] timeTextBoxes;

    [SerializeField]
    private TextMeshProUGUI dateTextBox;

    [SerializeField]
    private GameObject[] screens;

    private void OnEnable()
    {
        dateTextBox.text = System.DateTime.UtcNow.ToString("dd MMMM, yyyy"); // returns "12:48 15 April, 2013"
        StartCoroutine(StartClock());

        // Disable all screens
        ResetAllScreens();
        
        screens[0].SetActive(true); // Set lockscreen active
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartClock()
    {
        while (true)
        {
            timeTextBoxes[0].text = System.DateTime.Now.ToString("HH:mm");
            timeTextBoxes[1].text = System.DateTime.Now.ToString("HH:mm:ss");
            yield return null;
        }
    }

    public void ResetAllScreens()
    {
        foreach (GameObject screen in screens)
            screen.SetActive(false);
    }

    public void HomescreenNotepadPressed()
    {
        ResetAllScreens();
        screens[3].SetActive(true); // Set Notepad active
    }

    public void HomescreenMessagerPressed()
    {
        ResetAllScreens();
        screens[2].SetActive(true); // Set messenger active
    }

    public void OnInteract()
    {
        ResetAllScreens();
        screens[1].SetActive(true); // Set homescreen active
    }
}
