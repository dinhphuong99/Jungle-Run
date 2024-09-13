using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierActivator : MonoBehaviour
{
    public GameObject barrierUpper;
    public GameObject barrierBelow;
    
    private static int distanceBarrier;
    private int previousDistance = 1;
    private int countNormal;


    public GenRandomNumWorld genRandomNumWorld;
    public GroundRandom groundRandom;

    void Start()
    {
        barrierUpper.SetActive(false);
        barrierBelow.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void ActivateBarriers()
    {
        countNormal = genRandomNumWorld._worldState.CountNormal;
        // Khởi tạo giá trị ngẫu nhiên cho distanceBarrier
        distanceBarrier = 3;

        bool isUp = Random.value < 0.4f;
        bool isDivisible = countNormal % distanceBarrier == 0 && countNormal != 0;

        // Kiểm tra điều kiện để kích hoạt các vật cản
        if (
            countNormal - previousDistance > 1 && 
            isDivisible
            && Random.value < 0.95f
            )
        {
            barrierUpper.SetActive(isUp);
            barrierBelow.SetActive(!isUp);
            previousDistance = countNormal;
        }
        else
        {
            barrierUpper.SetActive(false);
            barrierBelow.SetActive(false);
        }
    }

    public bool IsBarrierUpperActive()
    {
        return barrierUpper.activeSelf;
    }

    public bool IsBarrierBelowActive()
    {
        return barrierBelow.activeSelf;
    }
}