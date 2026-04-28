using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Biblioteca de cambio de escenas*/

public class ChangeLevel1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        /*LoadScene.Single evita cargar mas de un nivel a la vez*/
    }
}
