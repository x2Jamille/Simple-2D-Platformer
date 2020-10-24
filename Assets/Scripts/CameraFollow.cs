using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    
    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
