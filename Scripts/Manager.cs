using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum gameStatus
{
    next,play, gameover,win
};

public class Manager : Loader<Manager>
{
    [SerializeField]
    int totalWaves = 4;
    [SerializeField]
    Text totalMoneyLabel;
    [SerializeField]
    Text currentWave;
    [SerializeField]
    Text playBtnLabel;
    [SerializeField]
    Button playBtn;

    [SerializeField]
    Button resumeBtn;

    [SerializeField]
    Image pausePanel;

    [SerializeField]
    Image imWin;
    [SerializeField]
    Image imLose;

    [SerializeField]
    Button secondBtn;
    [SerializeField]
    Button thirdBtn;

    [SerializeField]
    Text totalEscapedLabel;
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    Enemy[] enemies;
    [SerializeField]
    int totalEnemies = 5;
    [SerializeField]
    int enemiesPerSpawn;

    int waveNumber = 0;
    int totalMoney = 50;
    int totalEscaped = 0;
    int roundEscaped =0;
    int totalKilled = 0;
    int whichEnemiesToSpawn = 0;
    int enemiesToSpawn =0;
    gameStatus currentState = gameStatus.play;

    public List<Enemy> EnemyList = new List<Enemy>();

    private const float spawnDelay = 0.6f;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Загружает самую первую (0) установленную в проекте сцену. 
        // Если необходимо загрузить не её укажите какую именно сцену нужно загрузить
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        // Загружает самую первую (0) установленную в проекте сцену. 
        // Если необходимо загрузить не её укажите какую именно сцену нужно загрузить
    }


   //Всего сбежавших врагов
    public int TotalEscaped
    {
        get
        {
            return totalEscaped;
        }
        set
        {
            totalEscaped = value;
        }
    }

    //Прошло раундов
    public int RoundEscaped
    {
        get
        {
            return roundEscaped;
        }
        set
        {
            roundEscaped = value;
        }
    }

    //Всего уничтожено врагов
    public int TotalKilled
    {
        get
        {
            return totalKilled;
        }
        set
        {
            totalKilled = value;
        }

    }

    //Общее количество монет
    public int TotalMoney
    {
        get
        {
            return totalMoney;
        }
        set
        {
            totalMoney = value;
            totalMoneyLabel.text = totalMoney.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.gameObject.SetActive(false);
        imLose.gameObject.SetActive(false);
        imWin.gameObject.SetActive(false);
        secondBtn.gameObject.SetActive(false);
        thirdBtn.gameObject.SetActive(false);
        ShowMenu();
    }

    private void Update()
    {

    }


    //Появление противников
    private IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && EnemyList.Count < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (EnemyList.Count < totalEnemies)
                {
                    Enemy newEnemy = Instantiate(enemies[Random.Range(0, enemiesToSpawn)]) as Enemy;
                    newEnemy.transform.position = spawnPoint.transform.position;

                }
            }

            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(Spawn());
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        EnemyList.Add(enemy);
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        EnemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    //Уничтожение врагов
    public void DestroyEnemies()
    {
        foreach (Enemy enemy in EnemyList)
        {
            Destroy(enemy.gameObject);
        }
        EnemyList.Clear();
    }

    //Увеличение монет
    public void addMoney(int amount)
    {
        TotalMoney += amount;
    }

    public int subtractMoney(int amount)
    {
        if(TotalMoney > 0)
        {
            TotalMoney -= amount;
        }
        return TotalMoney;
    }

    //Окончание раундов
    public void IsWaveOver()
    {
        totalEscapedLabel.text = "Выживших врагов: " + totalEscaped + " / 10";

        if((RoundEscaped +  totalKilled) == totalEnemies)
        {
            if(waveNumber <= enemies.Length)
            {
                enemiesToSpawn = waveNumber;
            }
            SetCurrentGameState();
            ShowMenu();
        }
    }

    //Статус игры
    public void SetCurrentGameState()
    {
        if(totalEscaped >= 10)
        {
            currentState = gameStatus.gameover;
        }
        else if (waveNumber == 0 && (RoundEscaped + TotalKilled) == 0)
        {
            currentState = gameStatus.play;
        }
        else if (waveNumber >= totalWaves)
        {
            currentState = gameStatus.win;
        }
        else
        {
            currentState = gameStatus.next;
        }
    }

    //Нажатие на кнопку
    public void PlayButtonPressed()
    {
        switch (currentState)
        {
            case gameStatus.next:
                waveNumber += 1;
                totalEnemies += waveNumber;
                break;

            default:
                totalEnemies = 5;
                totalEscaped = 0;
                enemiesToSpawn = 0;
                totalMoneyLabel.text = TotalMoney.ToString();
                totalEscapedLabel.text = "Выживших врагов: " + TotalEscaped + " / 10"; 
                break;


        }
        DestroyEnemies();
        TotalKilled = 0;
        RoundEscaped = 0;
        currentWave.text = "Волна: " + (waveNumber + 1);
        StartCoroutine(Spawn());
        playBtn.gameObject.SetActive(false);

        imWin.gameObject.SetActive(false);
        imLose.gameObject.SetActive(false);
    }

    //Меню
    public void ShowMenu()
    {
        switch (currentState)
        {
            case gameStatus.gameover:
                playBtnLabel.text = "Попробовать снова?";
                imLose.gameObject.SetActive(true);
                pausePanel.gameObject.SetActive(true);
                resumeBtn.gameObject.SetActive(false);
                break;

            case gameStatus.next:
                playBtnLabel.text = "Следующая волна";
                playBtn.gameObject.SetActive(true);

                break;

            case gameStatus.play:
                playBtnLabel.text = "Играть";
                playBtn.gameObject.SetActive(true);


                break;

            case gameStatus.win:
                playBtnLabel.text = "Победа!";
                pausePanel.gameObject.SetActive(true);
                imWin.gameObject.SetActive(true);
                resumeBtn.gameObject.SetActive(false);

                break;
        }       
    }
}
