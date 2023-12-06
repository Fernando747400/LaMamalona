using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class ResetContraption : MonoBehaviour
{
    [Header("Dependencies")]

    [SerializeField] private List<GameObject> _objectsToReset = new List<GameObject>();

    private List<Vector3> initialPositions = new List<Vector3>();
    private List<Quaternion> initialRotations = new List<Quaternion>();

    private void OnEnable()
    {
        Populate();
    }

    [Button]
    public void ResetObjects()
    {
        for(int i = 0;  i < _objectsToReset.Count; i++)
        {
            _objectsToReset[i].transform.rotation = initialRotations[i];
            _objectsToReset[i].transform.position = initialPositions[i];
        }
    }

    private void Populate()
    {
        foreach (var obj in _objectsToReset)
        {
            initialPositions.Add(obj.transform.position);
            initialRotations.Add(obj.transform.rotation);
        }
    }
}
