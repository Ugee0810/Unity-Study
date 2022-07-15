# UnityStudy

### 22-07-04(Mon)
 - 유니티 개발 환경 구성
 - C# Script
   - GetComponent()
 - 기본 I/O
 - Metarial
 - RigidBody
 - Prefab

### 22-07-05(Tue)
 - 3D 벽돌깨기 게임

### 22-07-06(Wed)
 - UI Object(Image, Button)
 - 3D 탱크 슈팅 게임 생성
 - AssetStore
   - Import

### 22-07-07(Thu)
 - 2D 폭탄 피하기 게임 생성
 - Sprite
   - Sprite Renderer - Order in Layer 개념
   - Sprite Image
 - Animation
   - Samplate
 - Animator
   - Conditions(조건)
   - Parameters
     - In
     - Bull
     - Trigger
 - Image오브젝트의 fillAmount 개념(Hp바)
 - SceneManager.LoadScene("") - Scene 전환

### 22-07-12(Tue)
 - 유니티 활용 범위, 예시
 - 프로젝트 내 Resources 폴더 설명
 - Export Package(리소스 압축 및 배포 용이), Import Package
 - Object - Transform
   - Global Position(Hierarchy의 최상단 좌표계)
   - Local Position(부모 오브젝트를 기준으로 상속받는 좌표계)
 - Center와 Pibot 좌표(모델링의 배치 시, Pivot좌표계(모델링의 땅)로 배치하는게 용이하다.)
 - UI PNG 파일 2D Sprite 사용해 분리
 - Canvas 개념
 - 2D 'Flappy Bird' 게임 제작
   - 좌표계 공부
   - 안드로이드 베이스 - 화면 해상도 비율 자동 조정 스크립트
 - ★'GameManager'라는 스크립트 이름을 사용하면 톱니바퀴 아이콘으로 바꾸어 준다.(가시성, 로직을 전체 관리하는 중앙 스크립트 형식적 역할(생명 관리, 타임 어택 시간 관리 등)
 
### 22-07-13(Wed)
 - 유니티 C# 스크립트 생명주기 함수(이벤트의 처리 과정)
   - ![image](https://user-images.githubusercontent.com/85896566/178629812-9bb7680c-77b3-4678-9eb8-73eebe7e3a4a.png)
 - 좌표 이동의 방법
   - transform을 이용한 이동 - 움직인다는 느낌 보단 포지션만 변경된다는 느낌 Ex)총알
     - transform.Translate(Vector3.right * speed * Time.deltaTime);
     - transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime);
   - RigidBody를 이용한 이동 - 실제 중력을 받고 움직이는 내용
     - AddForce()
     - velocity
   - Time.deltatime
     - 컴퓨터의 성능을 보정하기 위해 사용
 - 2D 'Flappy Bird' 게임 제작
   - tag를 쓰지 않고 충돌처리 방법
   - Coroutine()과 Invoke()의 차이점
      - ![image](https://user-images.githubusercontent.com/85896566/178635850-f8bda70e-ff06-447a-bac3-48b141a2a76d.png)
      - 인보크는 2D 'Flappy Bird'의 'GameManager`스크립트 참조
   - OnTrigger와 OnCollision
   - SerializeField와 Serializable
     - https://daisy0461.tistory.com/23
   - HideInInspector(유니티 인스펙터 창에서 변수 숨기기)
   - Object Pooling
     - https://whiny.tistory.com/17
     - https://a6ly.dev/93
 - 3D 'UnityTest_220713'
   - RaycastHit ???; - 마우스포인터가 어디에 닿아있는지 캐치하는 것
   - normalized vs magnitude
     - https://neohtux.tistory.com/202
   - ★ObjectPool - 디펜스 웨이브나, 이펙트, 파티클처럼 무한반복하는 오브젝트들을 사전에 만들어두고 가져와 사용하는 기술로, 리소스 저하(GC,Garbage Collecter) 예방 가능
 - ★처음 다른 사람의 코드를 읽을 때 메인에서 스타트와 업데이트 내부로 파악하는 게 빠르다.  
 - ![image](https://user-images.githubusercontent.com/85896566/178686819-3e8246bb-14ab-4429-9adf-3e8354fba2a2.png)
   - 오브젝트 풀링을 사용하기 번거로울 때, Delegate를 사용하여 해당 오브젝트를 반응시킨다.
   - 예시)마법사가 친구들을 힐링해줄 때 오브젝트 풀링보단 대체자를 사용하는게 더 자연스러운 로직이기 때문
 ### 22-07-14(Thu)
 - 네트워크 이론과 게임 개발(포톤, 파이어베이스) 개념 공부, 실습
   - 레트로 강의 : 네트워크 게임 개발하기 - 이론 1/2 (로컬 플레이어와 리모트 플레이어)
     - https://youtu.be/z8KLb3lQofg
   - 레트로 강의 : 네트워크 게임 개발하기 - 이론 2/2 (서버-클라이언트와 권한 분리)
     - https://youtu.be/xJFadtTv5BI
       - Play as Host Server
         - 한 명의 플레이어가 서버 호스트가 되는 방식
         - 서버 비용이 절감된다.
         - 호스트의 PC사양과 인터넷 환경에 네트워크 품질이 달라진다.
       - Dedicated Server
         - 플레이어로 참여하지 않고 고정된 서버로서, 100% 자원을 게임 구동에 사용
         - 서버용 컴퓨터가 별개이므로, 네트워크 품질이 높다.
       - ★네트워크 공통 사항
         - 서버는 핵, 치팅 문제를 방지하기 위해 클라이언트를 절대 믿지 않는다.
         - 클라이언트는 총알을 쏘는 모션과 요청만 할 뿐, 호스트 게임 속에서 총알을 생성하고 물리 충돌이 발생한다. 이후 호스트 게임이 다른 클라이언트에게 정보를 전달한다.
         - 서버에서 일어난 일은 모든 클라이언트에서 일어난 일이고, 서버에서 일어나지 않은 일은 클라이언트에서도 일어나지 않았다.
         - 초당 패킷 교환 양이 높고, 손실을 최소화하는 게 좋은 서버
         - 효율적인 방법 : 모든 처리를 전부 동기화하면 네트워크 비용이 비싸지고 무겁다. 그래서 꼭 필요한 정보만 주고 받는다.(애니메이션은 전부 싱크 할 필요 없음) 총을 쏘거나 데미지를 갱신하는 중요한 일에 중점을 둔다.(이것도 당연히 호스트에게 요청하는 방식)
   - PhotonEngine
     - https://www.photonengine.com/ko-KR/
   - Firebase
     - https://firebase.google.com/?hl=ko
   - 레트로 강의 : Unity MultiPlayer Network Game Study (PhotonEngine + Firebase)
     - https://www.youtube.com/watch?v=-QsfDgvcheQ&list=PLctzObGsrjfwF7kkoraWb235U8Z602gx1
       - 1화
         - 데스크톱, 모바일 지원
         - 계정 인증 : 구글 파이어베이스
         - 네트워크 : 포톤
         - 구글이나 애플, 또는 이메일 계정으로 로그인
         - 포톤의 매치메이킹 서버를 통해 빈 방을 생성하거나 이미 생성된 방에 접속해 게임을 진행
         - 로컬과 리모트 오브젝트의 차이
         - RPC의 개념
         - 준비 프로젝트
       - 2화
         - 파이어베이스 유니티 SDK 다운로드 링크 : https://www.youtube.com/redirect?event=video_description&redir_token=QUFFLUhqbF9sbzNzVTB4S0p4MXBYSTR3Wnc1N3ZBTnNsQXxBQ3Jtc0tuN1ZweVotSVBVWjFGcXhuNkVQUXhHUHFLY3RESU81U3NWQ3FLTmd3Ml9oX3ZqRDludEcyQm51aF8ycndpT2NYdDJwaEdzdm9paTJ2NXRBaU5paDdNeVcxMFB2ek1HVlgzaGt1aVZJbHhURUxwbHNrNA&q=https%3A%2F%2Ffirebase.google.com%2Fdownload%2Funity%3Fhl%3Dko&v=0QY_W-7PSbI
         - 파이어베이스란? Only One BackEnd 플랫폼 - 백엔드 지식이 부족하더라도 복잡한 웹API 설계를 한 번에 대체할 수 있다.
         - 계정 인증을 위해 FirebaseAuth 임포트
         - 포톤 임포트
         - 파이어베이스 인식을 위해 앱의 식별자 변경
         - 신뢰할 수 있는 앱 - 키 설정
       - 3화
         - 포톤 네트워크와 유니티 앱 동기화
         - 파이어베이스와 유니티 앱 동기화
         - Firebase Authentication - 직접 로그인을 구현하지 않고 이 서비스를 사용하므로써, 한 번에 해결 가능
         - 파이어베이스 프로젝트 설정에서 디지털 지문 추가(JDK를 설치하고 환경 변수를 추가해야함)
         - 파이어베이스에서 사용자 추가(가입 구현x)
       - 4화
         - 유니티 로그인 화면 구현
           - Signin Scene의 Auth Manager 오브젝트에서 UI요소의 필드 값을 동기화함
           - ![image](https://user-images.githubusercontent.com/85896566/178981342-aa25fe63-327e-48b2-9d54-532d259bd7a6.png)
           - 제트브레인이라는 툴을 사용해야 하므로 완성본을 가지고 강의에 맞춰 따라간다.
### 22-07-15(Fri)
 - 2D 슈팅 게임 생성
   - GetAxis vs GetAxisRaw
     - GetAxis : 디테일한 동작을 연출하고 싶을 때 사용
     - GetAxisRaw : 방향에 대해 정보를 알고 싶을 때 : output ex) -1, 0, 1
     - RigidBody2D - Body Type
       - 1.Dynamic - 실제 물레엔진과 중력을 받음
       - 2.Kinematic - 스크립트 의존
       - 3.Static - 물리 계산만 함
     - OnTriggerEnter2D에서 Tag를 이용해 인게임에서 오브젝트들이 외부로 나가지 않게 트리거함
     - Animator와 Animation (https://novemberfirst.tistory.com/96)
     - 피격 스프라이트 구현
     - ★하이어라키에 있는 오브젝트는 프리팹에서 가져올 수 없다.(프리팹에서 프리팹으로는 가능)
 - 싱글톤, 오브젝트풀링, if절, invoke등을 사용하여 이벤트를 작성하여 

### 22-07-()
 - 
 - 

### 22-07-()
 - 
 - 

### 22-07-()
 - 멀티쓰레드
 - 위키북스 - 절대강좌 유니티
 - 
