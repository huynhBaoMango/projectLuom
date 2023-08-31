using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    float timeHientai;
    public float timetoCount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        timeHientai = timetoCount;
    }

    // Update is called once per frame
    void Update()
    {
        timeHientai -= 1 * Time.deltaTime;
        text.text = timeHientai.ToString("0");
        if(timeHientai <= 0)
        {
            timeHientai= 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menuketthuc");
        }
    }
}
