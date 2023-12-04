using UnityEngine;
using NaughtyAttributes;
using Obvious.Soap;

public class Toques : MonoBehaviour
{
    [Header("Dependencies")]

    [Tag]
    [SerializeField] private string _tubeTag;

    [Required]
    [SerializeField] private ScriptableEventBool _touchedTubeEventChannel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tubeTag))
        {
            _touchedTubeEventChannel.Raise(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_tubeTag))
        {
            _touchedTubeEventChannel.Raise(false);
        }
    }
}
