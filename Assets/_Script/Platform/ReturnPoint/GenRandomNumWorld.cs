using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomGenerator
{
    int GenerateRandomCount(int min, int max);
}

public class RandomGenerator : IRandomGenerator
{
    public int GenerateRandomCount(int min, int max)
    {
        return Random.Range(min, max);
    }
}

public class WorldState
{
    public int CountStart { get; set; } = 0;
    public int CountTransition { get; set; }
    public int CountNormal { get; set; }
    public int IsGroundLeft { get; set; } = 1;
    public int IsGroundMiddle { get; set; } = 1;
    public int IsGroundRight { get; set; } = 1;
    public bool StartRun { get; set; } = true;
    public bool IsNormal { get; set; } = false;
    public bool IsTransition { get; set; } = false;
}

public class GenRandomNumWorld : MonoBehaviour
{
    private IRandomGenerator _randomGenerator;
    public WorldState _worldState;

    void Start()
    {
        _randomGenerator = new RandomGenerator();
        _worldState = new WorldState();
        _worldState.CountStart = _randomGenerator.GenerateRandomCount(5, 8);
    }

    void Update()
    {
        //GenerateCountNumber();
    }

    public void GenerateCountNumber()
    {
        if (_worldState.CountStart < 1 && _worldState.StartRun)
        {
            _worldState.CountNormal = _randomGenerator.GenerateRandomCount(12, 16);
            ResetGroundState();
            _worldState.StartRun = false;
            _worldState.IsNormal = true;
        }
        else if (_worldState.CountTransition < 1 && _worldState.IsNormal)
        {
            _worldState.CountNormal = _randomGenerator.GenerateRandomCount(12, 16);
            SetRandomGroundState();
            _worldState.IsNormal = false;
            _worldState.IsTransition = true;
        }
        else if (_worldState.CountNormal < 1 && _worldState.IsTransition)
        {
            _worldState.CountTransition = _randomGenerator.GenerateRandomCount(3, 6);
            ResetGroundState();
            _worldState.IsTransition = false;
            _worldState.IsNormal = true;
        }
    }

    private void ResetGroundState()
    {
        _worldState.IsGroundLeft = 1;
        _worldState.IsGroundMiddle = 1;
        _worldState.IsGroundRight = 1;
    }

    private void SetRandomGroundState()
    {
        _worldState.IsGroundLeft = _randomGenerator.GenerateRandomCount(0, 2);
        _worldState.IsGroundMiddle = _randomGenerator.GenerateRandomCount(0, 2);

        if (_worldState.IsGroundLeft == 0 && _worldState.IsGroundMiddle == 0)
        {
            _worldState.IsGroundRight = 1;
        }
        else
        {
            _worldState.IsGroundRight = _randomGenerator.GenerateRandomCount(0, 2);
        }
    }

    public List<int> GenerateRandomResults(int numElements)
    {
        List<int> results = new List<int>();
        System.Random random = new System.Random();

        // Calculate the minimum number of 1s required
        int numOnes = numElements / 2;

        // Add the required number of 1s
        for (int i = 0; i < numOnes; i++)
        {
            results.Add(1);
        }

        // Add the remaining elements (either 0 or 1)
        for (int i = numOnes; i < numElements; i++)
        {
            results.Add(random.Next(0, 2)); // 0 or 1
        }

        // Shuffle the list to randomize the positions of 0s and 1s
        for (int i = results.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = results[i];
            results[i] = results[j];
            results[j] = temp;
        }

        return results;
    }
}