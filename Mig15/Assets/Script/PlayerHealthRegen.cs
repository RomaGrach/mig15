using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRegen : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Score;
    public int Count = 2;
    public float Maxhp;
    public float HeatlhPercent = 0.25f;
    private float Reg;
    [SerializeField] int Activations = 1;
    // Start is called before the first frame update
    void Start()
    {
        Maxhp = Player.GetComponent<playerGetDamage>().Maxhp;
        Reg = Maxhp * HeatlhPercent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.GetComponent<ScoreManager>().killedEnemies / Activations >= Count) {
            float hp = Player.GetComponent<playerGetDamage>().hp;
            if (hp < Maxhp)
                Player.GetComponent<playerGetDamage>().hp += Reg;
        Activations++;
        }
    }
}
