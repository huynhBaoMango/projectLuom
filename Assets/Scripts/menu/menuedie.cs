using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuedie : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
    {
        string mySavedScene = PlayerPrefs.GetString("sceneName");
        SceneManager.LoadScene(mySavedScene);
     
    }
    public void Quitgame()
    {
        Debug.Log("Quit Game");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("menubatdau");
    }
}
