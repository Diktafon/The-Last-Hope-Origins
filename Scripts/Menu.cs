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
        // ��������� ����� ������ (0) ������������� � ������� �����. 
        // ���� ���������� ��������� �� � ������� ����� ������ ����� ����� ���������
    }

    public void Exit()
    {
        Application.Quit();    // ������� ����������

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
