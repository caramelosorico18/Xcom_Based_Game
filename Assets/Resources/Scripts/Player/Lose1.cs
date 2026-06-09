using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("se cayó");
        if (GetComponent<Collider>().CompareTag("Player"))
        {
            SceneManager.LoadScene("lvl1", LoadSceneMode.Single);
        } //Recarga la escena si nos caemos
    }
}
