using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : Bullet
{
    Rigidbody rb;
    float angularPower = 2;
    float scaleValue = 0.1f;
    bool isShoot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(GainPowerTimer());
        StartCoroutine(GainPower());
    }

    IEnumerator GainPowerTimer()
    {
        yield return new WaitForSeconds(2.2f);
        isShoot = true;
    }

    IEnumerator GainPower()
    {
        // while문에서 증가된 값을 트랜스폼, 리지드바디에 적용
        while (!isShoot)
        {
            angularPower += 0.02f;
            scaleValue += 0.005f;
            transform.localScale = Vector3.one * scaleValue;
            // 속도를 올릴 것이므로 ForceMode.Acceleration 사용
            rb.AddTorque(transform.right * angularPower, ForceMode.Acceleration);
            // while문에선 yield return null을 포함하여 게임이 정지되는걸 막는다.
            yield return null;

        }
    }
}
