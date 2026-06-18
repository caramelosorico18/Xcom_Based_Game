using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsManager : MonoBehaviour
{
    public Rigidbody enemy;
    public GameObject spawnZone;
    public int rounds;
    private float multiplier;

    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        rounds = 1;
        Rounds();
    }
    private void Rounds()
    {
        for (float i = rounds; i > 25; i++)
        {
            multiplier = 12f + (i * 1.25f);
            for (float j = 1; j <= multiplier; j++)
            {
                GameObject.Instantiate(enemy, spawnZone.transform.position, Quaternion.identity);
            }
            rounds++;
        }
    }
}
