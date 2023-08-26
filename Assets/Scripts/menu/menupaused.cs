using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menupaused : MonoBehaviour
{
     public void resume()
    {
        SceneManager.LoadScene("SampleScene");
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
