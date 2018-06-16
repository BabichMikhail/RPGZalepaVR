using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK; 

public class GameStateController : MonoBehaviour
{
    public float ActionPoints;
    public float Health;
    public float Bullets;

    public string GameState;
    public GameObject[] Enemies;
    public GameObject Person;
    public GameObject[] Controllers;

    private Vector3 personPosition;
    private bool personInitialized = false;
    private int lastActiveEnemyIdxOffset = 0;

    private void Start()
    {
        
    }
    
    private void SetTeleportActive(bool active)
    {
        for (var i = 0; i < Controllers.Length; ++i)
            Controllers[i].GetComponent<VRTK_Pointer>().enabled = active;
    }

    void Update ()
    {
        var newPositon = Person.transform.position;
        ActionPoints -= (newPositon - personPosition).magnitude;
        personPosition = newPositon;

        if (ActionPoints <= 0.0f && GameState == "Free") {
            ActionPoints = 1.0f;
        }
        ActionPoints = Mathf.Max(0.0f, ActionPoints);

        var foundActiveEnemy = false;
        var foundActiveEnemyWithActionPoints = false;
        var flatPersonPosition = new Vector2(personPosition.x, personPosition.z);
        for (var i = 0; i < Enemies.Length; ++i) {
            int idx = (i + lastActiveEnemyIdxOffset) % Enemies.Length;
            var enemy = Enemies[i];
            if (enemy != null) {
                var enemyController = enemy.GetComponent<EnemyController>();
                var flatEnemyPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.z);
                if (!enemyController.GetActive() && (flatEnemyPosition - flatPersonPosition).sqrMagnitude < Mathf.Pow(enemyController.ActivationDistance, 2))
                    enemyController.SetActive(true);

                if (enemyController.GetActive()) {
                    foundActiveEnemy = true;
                    foundActiveEnemyWithActionPoints = enemyController.ActionPoints > 0.0f;
                }
            }
        }

        if (foundActiveEnemy && GameState == "Free")
            GameState = "FightStartMyTurn";
        else if (foundActiveEnemy && GameState == "FightMyTurn" && ActionPoints == 0.0f)
            GameState = "FightStartEnemyTurn";
        else if (foundActiveEnemy && GameState == "FightEnemyTurn" && !foundActiveEnemyWithActionPoints)
            GameState = "FightStartMyTurn";
        else if (!foundActiveEnemy)
            GameState = "Free";

        if (GameState == "FightStartMyTurn") {
            ActionPoints = 3.0f;
            GameState = "FightMyTurn";
            SetTeleportActive(true);
        }
        else if (GameState == "FightStartEnemyTurn") {
            for (var i = 0; i < Enemies.Length; ++i)
            {
                var enemy = Enemies[i];
                var enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController.GetActive())
                    enemyController.ActionPoints = 2.0f;
            }
            GameState = "FightEnemyTurn";
            SetTeleportActive(false);
        }
        else if (GameState == "Free")
            SetTeleportActive(true);


    }    
}
