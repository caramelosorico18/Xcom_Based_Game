using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("hit" + collision.gameObject.name + " !");
        }
        // Destruye la bala al colisionar con cualquier objeto
        Destroy(gameObject);
    }
}
