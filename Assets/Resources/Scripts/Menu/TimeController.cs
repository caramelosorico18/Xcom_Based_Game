using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class timeController : MonoBehaviour
{
    public GameObject menuPausa; /*Objeto menu pausa*/
    public float scaleAtRunTime; /*Escala de tiempo*/
    public void HandleTime()
    {
        if (Time.timeScale != 0)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Pause()
    {
        scaleAtRunTime = Time.timeScale;
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null); /*evitar que se pause con espacio*/
    }
    public void Resume()
    {
        Time.timeScale = scaleAtRunTime;
        menuPausa.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
