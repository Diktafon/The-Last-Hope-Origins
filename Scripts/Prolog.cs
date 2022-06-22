using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prolog : MonoBehaviour
{

    [SerializeField]
    Button menuBtn;

    public void Menu()
    {
        SceneManager.LoadScene(0);

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
