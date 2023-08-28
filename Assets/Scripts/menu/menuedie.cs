using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuedie : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
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
