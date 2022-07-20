using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject objects;
    public TextMesh scoreText;

    void Start()
    {

        //InvokeRepeating("CreateObjects", 1, 2); // CreateObjects() 메서드를 1초 후 호출, 2초 마다 재호출하는 메서드
        StartCoroutine("CreateObjects"); // 함수 호출
        //StartCoroutine(MyCoroutine(2));

        //// InvokeRepeating()과 StartCoroutine()의 사용 이유와 차이점
        // Invoke는 주기적으로 실행하기 위한 단순한 반복문 내용
        // 차이점 - 오브젝트가 비/활성화일 때 실행 유/무, 만약 주기별로 적이 무슨 액션을 할 때
        //      코루틴 - 적을 잡으면(비활성화)된다면 코루틴 로직도 비활성화
        //      인보크 - 적을 죽이더라도(비활성화) 인보크 로직은 활성화되어 있음
    }

    public int Score
    {
        set
        {
            score = value;
            scoreText.text = Score.ToString();
        }
        get
        {
            return score;
        }
    }

    void Update()
    {
        // 주기별 콜 하는 방법

    }
    
    IEnumerator MyCoroutine(int num)
    {
        //yield return new WaitForSeconds(2.0f);         // 게임 시간으로 2초마다 호출
        //yield return new WaitForSecondsRealtime(2.0f); // 실제 시간으로 2초마다 호출
        //yield return new WaitForFixedUpdate();         // 다음 FixedUpdate가 끝난 후 호출
        yield return new WaitForEndOfFrame();          // 프레임이 끝난 후 호출

        Instantiate(objects, new Vector2(8f, Random.Range(-1.3f, 2.5f)), Quaternion.identity);
    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector2(8f, Random.Range(-1.3f, 2.5f)), Quaternion.identity);
    }
}
