using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class playerGetDamage : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffectPrefab;
    public float hp = 5;
    public float Maxhp = 5;
    Image healthBar;
    [SerializeField] GameObject Image;
    [SerializeField] GameObject CanvasBeforDeath;
    [SerializeField] Image ImageBeforDeathfill;
    Image ImageBeforDeath;
    public bool BeforeDeth = false;
    public float TimeBeforDeath = 50;
    public float TimeBeforDeathStatic = 50;

    // Start is called before the first frame update
    void Start()
    {
        Maxhp = Progress.Instance.PlayerInfo.MaxHP;
        if (Maxhp <= 0)
        {
            Maxhp = 5;
            Debug.Log("_______________Ошибка сдоровья_______________");
        }
        hp = Maxhp;
        
        healthBar = Image.GetComponent<Image>();
        ImageBeforDeath = ImageBeforDeathfill.GetComponent<Image>();
        TimeBeforDeath = TimeBeforDeathStatic;
        YandexGame.RewardVideoEvent += Reward;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.fillAmount = hp / Maxhp;
        if (hp <= 0)
        {
            if(TimeBeforDeath == TimeBeforDeathStatic)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.LogError("РАБОТАЕТ1");
                BeforeDethStart();
            }
            else if(TimeBeforDeath == 0)
            {
                BeforeDethEnd();
                Debug.Log($"�� ����� �� ����");
                FindObjectOfType<GameManager>().ShowFinishWindowBadEnd();
                Destroy(gameObject);
            }
        }

        ImageBeforDeath.fillAmount = TimeBeforDeath / TimeBeforDeathStatic;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletEnemy")
        {
           
            hp -= other.gameObject.GetComponent<puly>().damage;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

    }
    private void FixedUpdate()
    {
        if (BeforeDeth)
        {
            
            TimeBeforDeath -= 1;
            Debug.Log(TimeBeforDeath);

        }
        if (TimeBeforDeath < 0)
        {
            BeforeDethEnd();
        }
    }
    public void BeforeDethStart()
    {
        CanvasBeforDeath.SetActive(true);
        Time.timeScale = 0.1f;
        BeforeDeth = true;
    }
    
    public void BeforeDethEnd()
    {
        CanvasBeforDeath.SetActive(false);
        Time.timeScale = 1f;
        BeforeDeth = false;
        TimeBeforDeath = 0;
    }
    public void ADReborn()
    {
        YandexGame.RewVideoShow(1100010);
    }
    void Reward(int id)
    {
        if (id == 1100010)
        {
            hp = Maxhp;
            BeforeDethEnd();
        }

    }
}
