using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    [SerializeField]
    Button oneBtn;
    [SerializeField]
    Button twoBtn;
    [SerializeField]
    Button threeBtn;
    [SerializeField]
    Button fourBtn;
    [SerializeField]
    Button fiveBtn;
    [SerializeField]
    Button sixBtn;
    [SerializeField]
    Button sevenBtn;
    [SerializeField]
    Button eightBtn;
    [SerializeField]
    Button nineBtn;
    [SerializeField]
    Button tenBtn;

    

    [SerializeField]
    Button menuBtn;

    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void Onelvl()
    {
        SceneManager.LoadScene(1);

    }

    public void Twolvl()
    {
        SceneManager.LoadScene(4);

    }

    public void Fourlvl()
    {
        SceneManager.LoadScene(5);

    }

    public void Threelvl()
    {
        SceneManager.LoadScene(6);

    }

    public void Fivelvl()
    {
        SceneManager.LoadScene(7);

    }

    public void Sixlvl()
    {
        SceneManager.LoadScene(8);

    }

    public void Sevenlvl()
    {
        SceneManager.LoadScene(9);

    }

    public void Eightlvl()
    {
        SceneManager.LoadScene(10);

    }

    public void Ninelvl()
    {
        SceneManager.LoadScene(11);

    }

    public void Tenlvl()
    {
        SceneManager.LoadScene(12);

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
