using UnityEngine;

public class KillWall : MonoBehaviour {
    
    // could just move this into the hammer script, use new tag for outer wall
    private void OnTriggerEnter(Collider other)
    {
        Hammer hammer = other.GetComponent<Hammer>();
        if(hammer != null)
        {
            HammerSpawner.Release(hammer);
        }
    }
}
