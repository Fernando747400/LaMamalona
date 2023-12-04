using UnityEngine;
using NaughtyAttributes;
using Obvious.Soap;

public class Bulb : MonoBehaviour
{
    [Header ("Dependencies")]

    [Required]
    [SerializeField] private ScriptableEventBool _touchedTubeEventChannel;

    [Required]
    [SerializeField] private GameObject _pointLight;

    private void OnEnable()
    {
        _touchedTubeEventChannel.OnRaised += ChangeBulbState;
    }

    private void OnDisable()
    {
        _touchedTubeEventChannel.OnRaised -= ChangeBulbState;
    }

    private void ChangeBulbState(bool state)
    {
        _pointLight.SetActive(state);
    }
}
