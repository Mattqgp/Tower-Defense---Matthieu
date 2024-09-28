using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    #endregion

    private void Start()
    {
        currentLevel = 0;
        NextLevel();
    }

    public int currentLevel;

    public void NextLevel()
    {
        currentLevel++;
        enemyAmount = Mathf.CeilToInt(currentLevel * 10 * 0.75f);
        EnemySpawner.Instance.SpawnEnemies();
    }

    public int enemiesInLevel;
    public int enemyAmount;

    public void AddEnemy()
    {
        enemiesInLevel++;
    }

    public void RemoveEnemy()
    {
        enemiesInLevel--;

        if (enemiesInLevel <= 0) 
            if (EnemySpawner.Instance.hasSpawnedAll) 
                NextLevel();
    }


}
