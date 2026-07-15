using UnityEngine;
using UnityEngine.UI;
public class PlayerMoney : MonoBehaviour
{
    public Text coinText;
    public int coinCount;

    public static PlayerMoney Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
     
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            coinCount = PlayerPrefs.GetInt("Money");
        }

        coinText = GameObject.FindGameObjectsWithTag("CoinText")[0].GetComponent<Text>();
        UpdateCoinsCount();
    }

    // Update is called once per frame
    void UpdateCoinsCount()
    {
        coinText.text = coinCount.ToString();
    }

    public void AddCoins()
    {
        coinCount ++;
        UpdateCoinsCount();
    }
}
