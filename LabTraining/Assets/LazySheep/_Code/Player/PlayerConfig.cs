using Autohand;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private AutoHandPlayer _autoHandPlayer;

    private void Start()
    {
        _autoHandPlayer.rotationType = RotationType.snap;
        _autoHandPlayer.maxMoveSpeed = 1f;
    }
    
    public void SnapRotation()
    {
        _autoHandPlayer.rotationType = RotationType.snap;
    }   
    
    public void SmoothRotation()
    {
        _autoHandPlayer.rotationType = RotationType.smooth;
    }
    
    public void FastSpeed()
    {
        _autoHandPlayer.maxMoveSpeed = 2f;
    }
    
    public void SlowSpeed()
    {
        _autoHandPlayer.maxMoveSpeed = 1f;
    }
}
