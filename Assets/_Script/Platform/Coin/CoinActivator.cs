// File: Assets/Scripts/CoinActivator.cs
using System.Collections.Generic;
using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    public GameObject[] coins; // 0: Above, 1: Below, 2: Front, 3: Back
    public GameObject barrierUpper;
    public GameObject barrierBelow;
    public GenRandomNumWorld genRandomNumWorld;
    public LayerMask playerLayerMask;

    private void Start()
    {
        DeactivateAllCoins();
    }
    private void Update()
    {
        
    }
    public void UpdateCoin()
    {
        if (ShouldActivateCoins())
        {
            ActivateCoins();
        }
        else
        {
            DeactivateAllCoins();
        }
    }
    private bool ShouldActivateCoins()
    {
        int countNormal = genRandomNumWorld._worldState.CountNormal;
        return countNormal > Random.Range(3, 6) && countNormal < Random.Range(10, 13);
    }

    private void ActivateCoins()
    {
        bool upperActive = barrierUpper.activeSelf;
        bool belowActive = barrierBelow.activeSelf;

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(Random.value < 0.2f);
        }

        // Deactivate specific coins based on barrier states
        if (upperActive)
        {
            coins[0].SetActive(false); // Above coin
            coins[1].SetActive(false); // Below coin
        }
        else if (belowActive)
        {
            coins[1].SetActive(false); // Below coin
        }
    }

    private void DeactivateAllCoins()
    {
        foreach (GameObject coin in coins)
        {
            coin.SetActive(false);
        }
    }
}