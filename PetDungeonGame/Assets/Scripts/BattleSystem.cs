using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState{Start, PlayerTurn, EnemyTurn, Won, Lost}

public class BattleSystem : MonoBehaviour
{
    public TurnState state;
        
    public GameObject PetPrefab;
    public GameObject EnemyPrefab;

    public Transform PetPosition;
    public Transform EnemyPosition;

    Unit playerUnit;
    Unit enemyUnit;

    void Start()
    {
        state = TurnState.Start;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(PetPrefab, PetPosition);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(EnemyPrefab, EnemyPosition);
        enemyUnit = enemyGO.GetComponent<Unit>();

        state = TurnState.PlayerTurn;
    }

    void onAttackButton()
    {
        
    }
}
