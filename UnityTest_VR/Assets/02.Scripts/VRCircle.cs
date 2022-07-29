using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCircle : MonoBehaviour
{
    public Image ImageOutCirecleGauge;
    public float totalTime = 2.0f;

    bool gvrStatus;
    float gvrTimer;

    private RaycastHit hit;

    void Awake()
    {
        VoiceManager.OnResult += OnResult;
    }

    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            ImageOutCirecleGauge.fillAmount = gvrTimer / totalTime;
        }

        // hit 정보 가져오기
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (ImageOutCirecleGauge.fillAmount == 1 && hit.transform.CompareTag("Teleport"))
            {
                //_movePos = hit.triangleIndex.gameobject.
                hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }    
        }
    }

    // 트래킹 성공 시 게이지 채워진다.
    public void GVROn()
    {
        gvrStatus = true;
    }

    // 게이지가 차던 중 벗어난다면
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        ImageOutCirecleGauge.fillAmount = 0;
    }



    void OnResult(string result)
    {
        Debug.Log(result);

        //if (result.Contains("move")) ;
        //{
        //    TeleportPlayer();
        //}
    }

    public void Move()
    {
        //transform.position = new Vector3(_movePos.position.x, _movePos);
    }
}
