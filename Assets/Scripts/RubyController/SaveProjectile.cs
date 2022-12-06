

using UnityEngine;

public class SaveProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            transform.GetComponent<AudioSource>().Play();
            controller.PorjectileSave();
            Destroy(transform.gameObject,1);
            
        }
    }

}
