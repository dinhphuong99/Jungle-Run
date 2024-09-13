using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRandom : MonoBehaviour
{
    public GameObject groundLeft;
    public GameObject groundMiddle;
    public GameObject groundRight;

    public GameObject returnPoint;
    public GenRandomNumWorld genRandomNumWorld;

    public GameObject[] landscapeLeft;
    public GameObject[] landscapeRight;

    public BarrierActivator[] barriers;

    public CoinActivator [] coins;

    List<int> randomLandscape = new List<int>();

    void Update()
    {
        
    }

    private void DecrementCount()
    {
        if (genRandomNumWorld._worldState.CountStart > 0)
        {
            genRandomNumWorld._worldState.CountStart--;
        }
        else if (genRandomNumWorld._worldState.CountNormal > 0)
        {
            genRandomNumWorld._worldState.CountNormal--;
        }
        else if (genRandomNumWorld._worldState.CountTransition > 0)
        {
            genRandomNumWorld._worldState.CountTransition--;
        }
    }

    public void SetGround(int isGroundLeft = 1, int isGroundMiddle = 1, int isGroundRight = 1)
    {
        groundLeft.SetActive(isGroundLeft >= 1);
        groundMiddle.SetActive(isGroundMiddle >= 1);
        groundRight.SetActive(isGroundRight >= 1);
    }

    public void CreateGround()
    {
        SetGround(genRandomNumWorld._worldState.IsGroundLeft,
                genRandomNumWorld._worldState.IsGroundMiddle,
                genRandomNumWorld._worldState.IsGroundRight);
        DecrementCount();

        foreach (BarrierActivator barrier in barriers)
        {
            barrier.ActivateBarriers();
        }

        foreach (CoinActivator coin in coins)
        {
            coin.UpdateCoin();
        }

        randomLandscape = genRandomNumWorld.GenerateRandomResults(landscapeLeft.Length);
        for (int i = 0; i < randomLandscape.Count; i++)
        {
            landscapeLeft[i].SetActive(true);
            landscapeRight[i].SetActive(true);
            if (randomLandscape[i] < 1)
            {
                landscapeLeft[i].SetActive(false);
                landscapeRight[i].SetActive(false);
            }
        }
    }
}