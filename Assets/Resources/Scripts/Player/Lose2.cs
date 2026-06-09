using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Lose;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy == false)
        {
            Lose.SetActive(true);
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("lvl1", LoadSceneMode.Single);
    }
}
