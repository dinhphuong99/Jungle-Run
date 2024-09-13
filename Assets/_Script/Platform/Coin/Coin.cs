using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinCollector coinCollector;
    public LayerMask playerLayerMask;
    public int coinValue = 1;

    private void OnTriggerEnter(Collider collision)
    {
        if (IsPlayer(collision))
        {
            CollectCoin();
        }
    }

    private bool IsPlayer(Collider collision)
    {
        return playerLayerMask == (playerLayerMask | (1 << collision.gameObject.layer));
    }

    private void CollectCoin()
    {
        GameManager.Instance.AddCoin(coinValue);
        coinCollector.CollectCoin();
        gameObject.SetActive(false); // Deactivate the coin object
    }
}