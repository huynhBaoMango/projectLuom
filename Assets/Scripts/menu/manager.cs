using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public void restart()
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
