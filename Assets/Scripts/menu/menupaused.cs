using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menupaused : MonoBehaviour
{
     public void resume()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Luom");
    }
    public void Quitgame()
    {
        Debug.Log("QUIT");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("menubatdau");
    }
}
