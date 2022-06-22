using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button lvlBtn;
    [SerializeField]
    Button exitBtn;
    [SerializeField]
    Button histiryBtn;

    public void Menulvl()
    {
        SceneManager.LoadScene(3);
        // Загружает самую первую (0) установленную в проекте сцену. 
        // Если необходимо загрузить не её укажите какую именно сцену нужно загрузить
    }

    public void Exit()
    {
        Application.Quit();    // закрыть приложение

    }

    public void Prolog()
    {
        SceneManager.LoadScene(2);

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
