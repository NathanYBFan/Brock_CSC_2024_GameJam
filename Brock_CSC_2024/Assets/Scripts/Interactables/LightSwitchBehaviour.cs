using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchBehaviour : Interactable
{
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("List of lights attached to this light switch")]
    private List<GameObject> lightsConnectedToSwitch;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("Bool to show if light is on or off")]
    private bool lightIsOn;

    public override void InteractedWith()
    {
        lightSwitchFlipped(!lightIsOn);

        Debug.Log("Turn Lights off");
    }

    public override void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }

    private void lightSwitchFlipped(bool lightState)
    {
        lightIsOn = lightState;

        foreach(GameObject light in lightsConnectedToSwitch)
            light.SetActive(lightState);
    }
}
