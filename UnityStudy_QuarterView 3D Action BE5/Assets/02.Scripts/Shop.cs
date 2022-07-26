using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    public Animator anim;

    public GameObject[] itemObj;
    public int[] itemPrice;
    public Transform[] itemPos;
    public Text talkText;
    public string[] talkData;

    Player enterPlayer;

    public void Enter(Player player)
    {
        enterPlayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

    public void Exit()
    {
        // 퇴장 시 애니메이션과 UI위치 이동
        anim.SetTrigger("doHello");
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }

    public void Buy(int index)
    {
        int price = itemPrice[index];
        // 금액이 부족하면 리턴
        if (price > enterPlayer.coin) 
        {
            // 이용자가 중복으로 누를 때 대사가 꼬이는걸 방지하기 위해 한 번 정지한다.
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }
        // 머니 차감
        enterPlayer.coin -= price;
        // randomVec 랜덤 벡터 변수 생성
        Vector3 randomVec = Vector3.right   * Random.Range(-3, 3)
                          + Vector3.forward * Random.Range(-3, 3);
        Instantiate(itemObj[index], itemPos[index].position + randomVec, itemPos[index].rotation);
    }

    IEnumerator Talk()
    {
        talkText.text = talkData[1];
        yield return new WaitForSeconds(2f);
        talkText.text = talkData[0];
    }
}
