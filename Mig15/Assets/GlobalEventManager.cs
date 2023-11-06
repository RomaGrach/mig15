using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnEnemyKilled = new UnityEvent();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    /*
    public static UnityEvent<int> OnEnemyKilled = new UnityEvent<int>();

    public static void SendEnemyKilled(int remainingCount)
    {
        OnEnemyKilled.Invoke(remainingCount);
    }
    //вызов
    //GlobalEventManager .SendEnemyKilled(enemiesRemainingNotification);
    / подписка
    GlobalEventManager.OnEnemyKilled.AddListener(remEnems=>
    {
        GetComponent<Text>().text = "Remain: " + remEnems;
    });
    */

}
