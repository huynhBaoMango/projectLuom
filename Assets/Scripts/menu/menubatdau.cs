using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubatdau : MonoBehaviour
{
    public void newgame()
    {
        SceneManager.LoadScene("level 1 remake");
    }
    public void Quitgame()
    {
        Debug.Log("QUIT");
    }
}
