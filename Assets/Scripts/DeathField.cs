using UnityEngine;

public class DeathField : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y);
    }
}
