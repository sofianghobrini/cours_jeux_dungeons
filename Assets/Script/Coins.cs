using UnityEngine;

public class Coins : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMoney.Instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
