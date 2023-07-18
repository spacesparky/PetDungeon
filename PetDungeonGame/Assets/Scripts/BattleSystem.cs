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

    BattleHUD battleui;

    void Start()
    {
        state = TurnState.Start;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(PetPrefab, PetPosition);
        battleui = playerGO.GetComponent<BattleHUD>();
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(EnemyPrefab, EnemyPosition);
        enemyUnit = enemyGO.GetComponent<Unit>();

        state = TurnState.PlayerTurn;
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        battleui.SetHP(enemyUnit.currentHP);
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        battleui.SetHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
             state = TurnState.Won;
             endBattle();
        } else
        {
            state = TurnState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    void endBattle()
    {
        if (state == TurnState.Won)
        {
            Debug.Log("win");
        } else if (state == TurnState.Lost)
        {
            Debug.Log("lost");
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (state == TurnState.PlayerTurn)
            {
                StartCoroutine(PlayerAttack());
            }
        } 
    }
}