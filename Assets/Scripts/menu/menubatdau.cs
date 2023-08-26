using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubatdau : MonoBehaviour
{
    public void newgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Quitgame()
    {
        Debug.Log("QUIT");
    }
}
