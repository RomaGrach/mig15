
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения
        public PlayerInfo PlayerInfo;
        /*
        public int Coins = 5;
        public int Killed = 0;
        public int Flight = 0;
        public float MaxHP = 5;
        public float Damage = 2;
        public float Armor = 1;
        public float TimeBetwinShots = 0.5f;
        public float TimeBetwinShots37 = 2f;
        public int Level = 0;
        public float Hprice = 5;
        public float Dprice = 5;
        public float Aprice = 5;
        public float Sprice = 5;
        public float S23price = 5;
        public float S37price = 5;
        */
        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            //Progress.Instance.PlayerInfo = YandexGame.savesData.PlayerInfo;
            //YandexGame.savesData.PlayerInfo = Progress.Instance.PlayerInfo;
            //PlayerInfo = Progress.Instance.PlayerInfo;
            openLevels[1] = true;
        }
    }
}
