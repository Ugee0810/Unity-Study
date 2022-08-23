# UnityStudy

### 22-07-04(Mon)
- 유니티 개발 환경 구성		 
- C# Script
  - GetComponent()
- 기본 I/O
- Metarial
- RigidBody
- Prefab
***


### 22-07-05(Tue)
- 3D 벽돌깨기 게임
***


### 22-07-06(Wed)
- UI Object(Image, Button)
- 3D 탱크 슈팅 게임 생성
- AssetStore
  - Import
***


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
***


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
***


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
  - [normalized vs magnitude](https://neohtux.tistory.com/202)
  - ★ObjectPool - 디펜스 웨이브나, 이펙트, 파티클처럼 무한반복하는 오브젝트들을 사전에 만들어두고 가져와 사용하는 기술로, 리소스 저하(GC,Garbage Collecter) 예방 가능
- ★처음 다른 사람의 코드를 읽을 때 메인에서 스타트와 업데이트 내부로 파악하는 게 빠르다.  
- ![image](https://user-images.githubusercontent.com/85896566/178686819-3e8246bb-14ab-4429-9adf-3e8354fba2a2.png)
  - 오브젝트 풀링을 사용하기 번거로울 때, Delegate를 사용하여 해당 오브젝트를 반응시킨다.
  - 예시)마법사가 친구들을 힐링해줄 때 오브젝트 풀링보단 대체자를 사용하는게 더 자연스러운 로직이기 때문
***


### 22-07-14(Thu)
- 네트워크 이론과 게임 개발(포톤, 파이어베이스) 개념 공부, 실습
  - [레트로 강의 : 네트워크 게임 개발하기 - 이론 1/2 (로컬 플레이어와 리모트 플레이어)](https://youtu.be/z8KLb3lQofg)
  - [레트로 강의 : 네트워크 게임 개발하기 - 이론 2/2 (서버-클라이언트와 권한 분리)](https://youtu.be/xJFadtTv5BI)
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
  - [PhotonEngine](https://www.photonengine.com/ko-KR/)
  - [Firebase](https://firebase.google.com/?hl=ko)
  - [레트로 강의 : Unity MultiPlayer Network Game Study (PhotonEngine + Firebase)](https://www.youtube.com/watch?v=-QsfDgvcheQ&list=PLctzObGsrjfwF7kkoraWb235U8Z602gx1)
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
      - [파이어베이스 유니티 SDK 다운로드](https://www.youtube.com/redirect?event=video_description&redir_token=QUFFLUhqbF9sbzNzVTB4S0p4MXBYSTR3Wnc1N3ZBTnNsQXxBQ3Jtc0tuN1ZweVotSVBVWjFGcXhuNkVQUXhHUHFLY3RESU81U3NWQ3FLTmd3Ml9oX3ZqRDludEcyQm51aF8ycndpT2NYdDJwaEdzdm9paTJ2NXRBaU5paDdNeVcxMFB2ek1HVlgzaGt1aVZJbHhURUxwbHNrNA&q=https%3A%2F%2Ffirebase.google.com%2Fdownload%2Funity%3Fhl%3Dko&v=0QY_W-7PSbI)
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
***


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
    - [Animator와 Animation](https://novemberfirst.tistory.com/96)
    - 피격 스프라이트 구현
    - ★하이어라키에 있는 오브젝트는 프리팹에서 가져올 수 없다.(프리팹에서 프리팹으로는 가능)
- [싱글톤, 오브젝트풀링, if절, invoke등을 사용하여 이벤트를 작성하여 개선 가능](https://wjtbgamechallenge.com/)
***


### 22-07-18(Mon)
- 2D 슈팅 게임 진행
  - 오브젝트풀링 스크립트(ObjectManager) 생성 후 개념 정리
  - ★prefab에 오브젝트 할당
    - ![image](https://user-images.githubusercontent.com/85896566/179443077-931207af-bcf9-4707-9875-6c1601f68c34.png)
- Assets의 Resources폴더 - 모든 플랫폼에서 공통된 경로이므로, 앱이 실행될 때, 로딩될 때 데이터들을 저장하게 된다.
- 외부 txt파일을 참조하고, 데이터를 읽어오는 방법
  - ![image](https://user-images.githubusercontent.com/85896566/179451646-0c423fb5-bb03-4b2e-95f2-0fd3d14654be.png)
- 유니티 디버그 방법
  - 오류를 구글링 한 후 콘솔의 상세 설명 맨 아래부터 찾아가 브레이크 포인트를 건다. 다만, 함수 내부에서의 추적일 때, 그 밑 줄에 리턴하고 리턴에 브레이크 포인트를 건다.
  - 프로젝트 실행 후 원인을 파악해보고, 아직 잘 모른다면 단어에서 전체 찾기(Ctrl+Shift+F)를 한다.
- 골드메탈 - 유니티 게임오브젝트의 흐름
  - Awake()
    - 초기화 영역
    - 최초 1회
    - Debug.Log("플레이어 데이터가 준비되었습니다.");
  - OnEnable()
    - 오브젝트가 활성화 될 때 마다 실행
    - Awake()보다는 늦게, Start()보단 빠르게
    - Debug.Log("플레이어가 로그인했습니다.");
  - Start()
    - 초기화 영역
    - 최초 1회
    - Debug.Log("사냥 장비를 챙겼습니다.");
  - ![image](https://user-images.githubusercontent.com/85896566/180678681-bc603ecb-0aa1-4f28-8202-117ed510f7fc.png)
  - FixedUpdate()
    - 물리 연산 영역
    - 물리 연산 하기 전에 실행
    - 고정된 실행 주기로 CPU를 많이 사용
    - 약 1초/50회
    - Debug.Log("이동~");
  - Update()
    - 게임 로직 영역
    - 환경에 따라 실행주기 변동 있음
    - Debug.Log("몬스터 사냥!!");
  - LateUpdate()
    - 모든 업데이트 끝난 후 마지막으로 실행
    - 보통 캐릭터를 따라가는 카메라나, 아이템, 경험치 등 후처리
    - Debug.Log("경험치 획득"); 
  - OnDisable()
    - 비활성화 영역
    - 스크립트가 비활성화 됐을 때 실행
    - Debug.Log("플레이어가 로그아웃 했습니다.");
  - OnDestroy()
    - 해체 영역(Awake의 반대)
    - 오브젝트가 삭제될 때 1회 실행
    - Debug.Log("플레이어 데이터를 해제하였습니다.");
***


### 22-07-19(Tue)
- 골드메탈 - UGUI 기초
  - Canvas : UI가 그려지는 도화지 같은 역할
    - 하이어라키에 아래로 갈 수록 최근에 그려진 것(상단)
    - 스크린 
    - 텍스트 : 상업적 용도로 사용 가능한 폰트인지 확인할 것
    - 이미지 : 소스 이미지를 받는 UI(Sprite(2D and UI)로 변경 후) 
    - 버튼 : 반응형 클릭 이벤트를 가진 UI 
    - 앵커 : 빨간점 - 캔버스에서의 기준점 / 파란점(Shift) - 컴포넌트에서의 기준점 / 중앙네모(Alt) - 컴포넌트의 위치
- [골드메탈 - 2D 종스크롤 슈팅 - 플레이어 이동 구현하기](https://youtu.be/ETYzjbnLixY)
***


### 22-07-20(Wen)
- 포트폴리오 - 다양한 게임 예제를 만드는 건 좋지만, 그 보다 다양한 로직으로 만드는 것이 더 중요하다.
- 오늘의 수업 내용 - 두 가지의 디자인 전략 패턴으로 기존의 스크립트를 리팩토링하는 내용
  - 2D 슈팅 게임 진행
    - 전략 디자인 패턴 로직 - 타입에 따른 분류 방법 채택
  - 2D 로그라이크 게임 진행
    - [에셋스토어](https://assetstore.unity.com/packages/templates/tutorials/2d-roguelike-29825)
    - [튜토리얼](https://api.unity.com/v1/oauth2/authorize?client_id=unity_learn&locale=ko_KR&redirect_uri=https%3A%2F%2Flearn.unity.com%2Fauth%2Fcallback%3Fredirect_to%3D%252Fproject%252F2d-roguelike-tutorial&response_type=code&scope=identity+offline&state=3957df67-37c5-4966-9928-1569fc43ea53)
    - 스크립트 자체적으론 굉장히 좋은 예제, 동영상도 참조
    - 직렬화를 해야할 때 랜덤 함수를 사용하려면 이렇게 Using한다.
      - ![image](https://user-images.githubusercontent.com/85896566/179930326-2c099dc3-cde3-42ef-a37f-9faef2bb4a1c.png)
    - Tag가 아닌 Layer를 통해 이동 제한하기
    
- 디자인 패턴
  - 객체 지향 프로그래밍 설계를 할 때 자주 발생하는 문제들을 피하기 위해 사용되는 패턴. 여러 사람이 협업해서 개발할 때 다른 사람이 작성한 코드, 기존에 존재하는 코드를 이해하는 것은 어렵다. 이런 코드를 수정하거나 새로운 기능을 추가해야 하는데 의도치 않은 결과나 버그를 발생시키기 쉽고 성능을 최적화시키기도 어렵다. 이로 인해 시간과 예산이 소모된다.</br>
디자인 패턴은 의사소통 수단의 일종으로서 이런 문제를 해결해준다. 예를 들어 문제 해결의 제안에 있어서도 “기능마다 별도의 클래스를 만들고, 그 기능들로 해야할 일을 한번에 처리해주는 클래스를 만들자.”라고 제안하는 것보다 "Facade 패턴을 써보자."라고 제안하는 쪽이 이해하기 쉽다.</br>
일반 프로그래머가 만나는 문제가 지구상에서 유일한 문제일 확률은 거의 없다. 이미 수많은 사람들이 부딪힌 문제다. 따라서 전문가들이 기존에 해결책을 다 마련해 놓았다.
  - [Strategy Pattern(전략 패턴)](https://victorydntmd.tistory.com/292)
    - ![image](https://user-images.githubusercontent.com/85896566/179891408-e7c4485f-7be5-4b86-941a-50bf8a1d63bd.png)
    - ![image](https://user-images.githubusercontent.com/85896566/180203222-ef0e1292-c41d-4bc5-844d-9aceca4d0e0b.png)

  - 프로토 타입 패턴
    - 같은 오브젝트이더라도 성질을 다르게 하여 생성하는 것(EX.체력, 데미지 등)
  - [Factory Method Pattern](https://victorydntmd.tistory.com/299?category=719467)
  - [Singleton Pattern](https://victorydntmd.tistory.com/293?category=719467)
    - ![image](https://user-images.githubusercontent.com/85896566/180203062-cdfc058f-22a7-4ea7-9824-31db0811f650.png)
    
***


### 22-07-21(Thu)
- [[인프런 - retr0]유니티 2D 로그라이크 게임 만들기 [한글자막]](https://www.inflearn.com/course/%EC%9C%A0%EB%8B%88%ED%8B%B0-3d-%EA%B2%8C%EC%9E%84-%EB%A7%8C%EB%93%A4%EA%B8%B0/)
  - 1화
    - 에셋스토어에서 임포팅 후 태그, 레이어, 솔팅레이어 적용 확인 / 프로젝트 설정
  - 2화
    - 플레이어, Enemy1/2 프리팹 제작
    - Animation Override Controller 사용하여 Enemy1의 애니메이션을 Enemy2로 재정의
  - 3화
    - 바닥, 음식, 방해물, 출구 같은 요소 프리팹화
- 디자인 패턴 개념과 대표적인 종류에 대해서 알아보았다.
***


### 22-07-22(Fri)
- 2D 로그라이크2 게임 수업 진행
  - 게임 오브젝트 프리팹 생성
  - 태그, 레이어, 솔팅레이어 정의 및 적용
  - ![image](https://user-images.githubusercontent.com/85896566/180345514-34601301-ea57-4425-8faa-c1be6cab24e0.png)
    - 보드 매니저 스크립트 - 각 스테이지별 오브젝트 생성에 대한 로직을 구성하는 스크립트
    - 게임 매니저 스크립트 - 몬스터가 자동으로 움직일 수 있게 하는 로직
    - 오디오 매니저 스크립트 사용
    - 광고 설정
      - 구글 플레이 콘솔
      - 구글 애드몹
      - 유니티 內 설정
- Mathf 클래스 함수 - 기본 수학 함수가 내장되어있는 클래스
- 디자인 패턴 필수 공부
  - 전략
  - 팩토리
  - 옵저버
  - 커맨드
  - 싱글톤
- 객체 이동
  - Movetowards : [A to B] 정해진 위치까지만 이동하는 방법
- ![image](https://user-images.githubusercontent.com/85896566/180353939-44a3d3fe-5453-4ebf-ac97-b1fde02dfd23.png)
- ![image](https://user-images.githubusercontent.com/85896566/180355105-fd282669-2a09-4b76-a9de-ffc87430f5bd.png)
- ![image](https://user-images.githubusercontent.com/85896566/180355546-1d00fc7b-8691-48bb-8b7f-07d04e1a4f1c.png)
- ★UML 다이어그램
***


### 22-07-23(Sat)
- [골드메탈 - QuarterView 3D Action BE5](https://youtu.be/WkMM7Uu2AoA)
  - 1화
    - Floor, Wall, Material, Player 생성
    - Player 스크립트
      - 이동 구현 - transform
      - 걷는 속도 조절 - 삼항연산자 : [Bool 형태 조건 ? true값 : false값]
      - 애니메이션 초기화 : GetComponentInChildren<>() - 자식 오브젝트에 있는 컴포넌트를 가져온다.
      - 회전 구현 - transform.LookAt() - 지정된 벡터를 향해서 회전시켜주는 함수
    - RigidBody - Collsion Detection - Continuous : CPU를 더 사용해서 물리계산 빈도를 높인다.
    - 카메라의 플레이어 유도 이동 구현
      - Follow 스크립트
        - ![image](https://user-images.githubusercontent.com/85896566/180601580-bdfdf2fd-830f-4518-8402-39b60a8c22e2.png)
  - 2화
    - 점프 구현
    - 지형 물리 강화(Physic Metarial)
    - 회피 구현
***


### 22-07-24(Sun)
- [골드메탈 - QuarterView 3D Action BE5](https://youtu.be/WkMM7Uu2AoA)
  - 3화
    - 아이템 구현
    - 라이트 이펙트
    - 파티클 이펙트
      - Emission : 파티클 입자 출력양
      - Shape : 파티클 입자 출력 모양
      - Limit Velocity over Lifetime : 시간에 따른 속도제한
      - Color over Lifetime : 시간에 따른 색상변화
      - Size over Lifetime : 시간에 따른 크기변화
    - 로직 구현
      - enum으로 아이템 타입 열거
      - 오브젝트 회전 효과
  - 4화
    - 드랍 무기 입수 후 장착 로직 구현
    - 무기 교체 및 애니메이션 구현
  - 5화
    - 아이템 입수 후 value 변경
    - 수류탄 플레이어 주변 공전 + 파티클 구현
    - 수류탄 습득 시 플레이어 주변 활성화 구현
  - 6화
    - 근접 공격 구현
      - Trail Renderer 컴포넌트로 이펙트 구현
      - Coroutine
        - ![image](https://user-images.githubusercontent.com/85896566/180647832-f9de06e8-384e-4d56-976a-77be2691c2f9.png)
***


### 22-07-25(Monday)
- 수업 내용과 유튜브 강의의 차이점
  - 전체 중력을 바꾸면 캐릭터 별로 차별화할 수 없으므로 Constant Force 컴포넌트를 오브젝트별로 추가하여 차별화 할 수 있다.
  - AddForce
    - ![image](https://user-images.githubusercontent.com/85896566/180682478-12732aed-af13-46d5-a46f-95ce5c74c7e3.png)
- [골드메탈 - QuarterView 3D Action BE5](https://youtu.be/WkMM7Uu2AoA)
  - 7화
    - 원거리 공격 구현
      - 총알, 탄피 생성, 스크립트
      - 발사 구현
      - 재장전 구현
  - 8화
    - 플레이어 자동 회전 방지
    - 충돌 레이어 설정
      - ![image](https://user-images.githubusercontent.com/85896566/180722967-0ea72e44-c9a5-4a44-aae3-380991feb4bc.png)
    - 벽 관통 방지
      - 레이어 마스크로 벽 레이어에 충돌 제한 적용
    - 아이템 충돌 제거
      - 스크립트로 태그와 충돌 시 RigidBody - isKinematic = true / Collider.enabled = false로 해준다.
      - GetComponent() 함수는 중복 컴포넌트일 때 가장 첫 번째 컴포넌트만 가져오므로 주의한다.
   - 9화
     - 수류탄 구현
     - 수류탄 투척
     - 수류탄 폭발
       - 폭발 이펙트를 비활성화 해두고, 코루틴 함수로 3초 뒤 활성화시킨다.
       - 메쉬 오브젝트는 최초 활성화 후 위와 동일하게 비활성화 시킨다.
     - 수류탄 피격
       - 공 모양의 레이캐스트 사용
       - SphereCastAll() - 구체 모양의 레이캐스팅(모든 물체)
   - 10화
     - Enemy Ai 구현
       - 유니티가 제공하는 Nav A.I
       - NavMesh - NavAgent가 경로를 그리기 위한 바탕(Mesh)
       - NavMesh는 Static 오브젝트만 Bake 가능(Wall)
       - 다른 오브젝트와 충돌시 이동 값이 변경되는 걸 예방하기 위해 FreezeVelocity() 함수 추가
         - ![image](https://user-images.githubusercontent.com/85896566/180782281-0c1aa460-b48e-4e88-a4b4-0eab906e1b44.png)

- [디자인 패턴 공부]
  - [싱글톤 패턴](https://youtu.be/-oy5jOd5PBg)
  - [[생성 패턴] 싱글톤(Singleton) 패턴을 구현하는 6가지 방법](https://readystory.tistory.com/116)
  - [유니티 디자인패턴 - 싱글톤 (Unity Design Patterns - Singleton)](https://glikmakesworld.tistory.com/2)
  - [유니티 디자인패턴 - 팩토리(심플팩토리, 팩토리 메소드, 추상팩토리) (Unity Design Patterns - Factory)](https://glikmakesworld.tistory.com/5?category=797136)
***


### 22-07-26(Tue)
- [골드메탈 - QuarterView 3D Action BE5](https://youtu.be/WkMM7Uu2AoA)
  - 10화
    - 플레이어 피격
      - OnTriggerEnter에서 EnemyBullet 태그 적용
      - Bullet 스크립트의 데미지 로직 사용
      - OnDamage() 코루틴을 이용해 피격(Material을 이용한 색 변환) 및 무적 구현
    - 몬스터 움직임 보완
      - ![image](https://user-images.githubusercontent.com/85896566/180908751-bc20ae8a-6335-4852-aa7f-08d7a809ef0a.png)  
    - 몬스터 공격
      - FixedUpdate() -> Targeting()
        - 변수 - 구체 반지름, ray 거리 생성
        - 기본 Ray를 사용하면 가늘어서 판정하기 어려우므로, 수류탄에서 사용한 SphereCastAll() 사용
        - ![image](https://user-images.githubusercontent.com/85896566/180909594-83644731-5fc4-414d-8b6e-0e68a5bfa367.png)
      - IEnumerator Attack()
        - 공격 타입대로 구현
        - ![image](https://user-images.githubusercontent.com/85896566/180909840-86fe422d-2ba6-4786-b453-2296fa29bd56.png)
    - 일반형 몬스터
    - 돌격형 몬스터
    - 원거리형 몬스터
      - 미사일 프리팹, 이펙트, 생성, 삭제 로직 구현
  - 11화
    - 보스 기본 세팅
      - 애니메이션 구현
      - 프리팹, 컴포넌트 생성
        - 미사일 오브젝트 2개 추가
        - 근접 공격(땅 찍기) 오브젝트와 콜라이더 컴포넌트
    - 투사체 추가
      - 미사일
        - 투사체가 회전하면서 파티클이 망가지지 않도록 파티클 컴포넌트에서 Simulation Space를 월드 좌표로 변경
        - 유도 미사일이므로 Nav 컴포넌트 추가
        - Bullet 스크립트를 상속 받는 BossMissaile 스크립트 추가
      - 바위
        - 구르기 때문에 Mass(무게)와 Angular Drag(회전 저항)을 설정
        - Bullet 스크립트를 상속 받는 BossRock 스크립트 추가
        - 상속된 스크립트에서 Floor에 닿으면 3초 뒤 삭제 되는 구문에서 isRock bool 조건 추가
   - 보스 로직 준비
      - Enemy 스크립트 상속하며 수정한다.
        - ![image](https://user-images.githubusercontent.com/85896566/180915367-5e97c3e0-cb8f-440c-a20b-87d0b3698720.png)
      - 플레이어 이동 예측 로직
      - 상속을 할 때 주의점 : Awake() 함수는 자식 스크립트만 단독 실행!!
        - ![image](https://user-images.githubusercontent.com/85896566/180917789-361ba551-0ce0-424a-a410-d70b11ae2325.png)
  - 12화
    - UI 배치하기
      - 캔버스 세팅
      - [쿠키런 무료 폰트](https://www.cookierunfont.com/)
      - 메뉴 판넬
      - 게임 판넬
        - 스코어 그룹, 스테이터스 그룹, 스테이지 그룹, 적 그룹
        - 장비 UI
        - 보스 체력 UI
  - 13화
    - 상점 구현
    - ![image](https://user-images.githubusercontent.com/85896566/180948352-9d2c86ae-48ce-44e7-a247-94fa6880a0af.png)
  - 14화
    - UI와 데이터 로직 연결
      - 움직이는 메인 화면 카메라 로직
      - 메인 화면 최고 기록 
      - 유니티에서 자동으로 저장해주는 인자값과 함수
        - ![image](https://user-images.githubusercontent.com/85896566/180962147-ab2303da-ce3a-4f45-8b9b-8affc3eeba5a.png)
        - ','을 자동으로 넣어주며 저장된 스코어를 받아오는 것
          - ![image](https://user-images.githubusercontent.com/85896566/180966292-08d477d9-e45b-465a-8130-647240d191e3.png)
  - 15화
    - 스테이지 관리
      - 스타트존을 만들고 로직 연결
      - 몬스터 생성
    - 몬스터 코인 드랍
    - 첫 실행할 때는 PlayerPrefs의 Key 세팅이 필요
      - ![image](https://user-images.githubusercontent.com/85896566/181155422-43d4743a-e71f-4e2e-bcc4-c4d5703483eb.png)
    - 사운드 연결
    - 빌드
***


### 22-07-27(Wen)
- 베르의 게임 채널 네트워크 공부
- 포톤네트워크 기본
  - 에셋 Fun2 임포트 및 ID인증
  - 프리팹에 포톤 스크립트 추가
  - ![image](https://user-images.githubusercontent.com/85896566/181198136-439e04a1-f23e-4f8c-86e6-30df02ea028d.png)
  - 커넥션을 위한 'MatchMaker' 스크립트 생성
  - ![image](https://user-images.githubusercontent.com/85896566/181209672-aa1e0126-0c10-4cfe-a2b5-77ad24355e92.png)
  - 이후 앱 id로
***


### 22-07-28(Thu)
- [CharacterController 컴포넌트 클래스](https://docs.unity3d.com/kr/2021.1/Manual/class-CharacterController.html)
- [유니티 매뉴얼 Unity-XR](https://docs.unity3d.com/kr/2021.1/Manual/XR.html)
  - ![image](https://user-images.githubusercontent.com/85896566/181408453-918af70a-1db2-455b-96b2-4715023768e7.png)
- Photon과 FireBase를 이용한 서버 구축
  - PakegeManager Import
  - Build Setting - Android
  - PUN Wizard - Setup Project - Photon App ID
  - FireBase Create Project - 앱 추가 순서 1. 패키지 매니저 SDK 2. 패키지 네임 추가 3. JSON 파일 프로젝트 폴더에 보관
  - 계정 등록 설정
  - 디지털 지문 등록
***


### 22-07-29(Fri)
- VR 예제 연습(UnityTest_VR)
  - Basic Setting
    - Project Setting
      - Other Setting : 오류 방지
        - ![image](https://user-images.githubusercontent.com/85896566/181666895-faf9341f-640b-468c-89c6-38ca74eb7c01.png)
      - XR Setting
        - ![image](https://user-images.githubusercontent.com/85896566/181667399-d5274271-65ae-4096-b0aa-158ad2703119.png)
    - ※ GVR SDK Pakage Setup
      - [GVR SDK for Unity v1.200.1](https://github.com/googlevr/gvr-unity-sdk/releases)
 - GvrEditorEmulator Prefab -> 기본 적인 무빙 가능
    - ![image](https://user-images.githubusercontent.com/85896566/181668815-ce9bd903-df56-479d-a7f1-c28889ab8fb3.png)
    - ![image](https://user-images.githubusercontent.com/85896566/181668937-f99b3c8d-320c-4a5a-a064-e13e651ff4a7.png)
 - GvrReticlePointer Prefab-> 커서, 레이저
   - ![image](https://user-images.githubusercontent.com/85896566/181668982-51d4ac6c-ffee-4817-8b4f-e0f0a5c7645a.png)
   - 레이어 설정은 자신을 감지하면 안되므로 'Ignore Raycast'로 설정되어 있다.
 - GvrPointerPhysicsRaycaster Script -> 레이캐스트 정보
   - ![image](https://user-images.githubusercontent.com/85896566/181669307-bebb7a0d-a105-4b38-bcfa-4c22287b3c1f.png)
 - GvrEventSystem Prefab -> 이벤트 발생 시 처리
   - ![image](https://user-images.githubusercontent.com/85896566/181669476-5462035a-34a2-421c-bc25-53dc487046ee.png)
 - 텔레포트(테스트)의 컴포넌트에 Event Trigger 추가 시 GvrEventSystem가 작용
   - ![image](https://user-images.githubusercontent.com/85896566/181672063-fc947dc9-fbb8-490b-91f3-7f47ed7f9e24.png)
 - 보통의 VR은 보는 쪽으로 이동한다.
   - UI도 플레이어에게 상속시키고 거리를 줄여준다.
     - ![image](https://user-images.githubusercontent.com/85896566/181672801-e9e6ca8a-2703-4d87-b816-20aa089bf866.png)
   - 트래킹 포인트 만들기
     - ![image](https://user-images.githubusercontent.com/85896566/181673253-533adfba-08aa-4882-a041-3d9870b8046c.png)
   - 포인터 동작
     - ![image](https://user-images.githubusercontent.com/85896566/181673851-3d950deb-7150-4743-afa0-28b81dc29d85.png)
     - 타겟에게도 이벤트 트리거를 걸어야 한다.
       - ![image](https://user-images.githubusercontent.com/85896566/181674065-d461628b-4de9-40ac-94c5-19871027fd8e.png)
 - 캔버스에서 그래픽 레이캐스터를 없애야 한다.
- 구글 클라우드 : 음성 인식 기술

- [Speech_Recognition_using_Google_Cloud_VRARMobileDesktop_Pro.unitypackage](https://cdn.discordapp.com/attachments/996281490570743902/1002427638763229294/Speech_Recognition_using_Google_Cloud_VRARMobileDesktop_Pro.unitypackage)
***


### 22-08-01(Mon)
- Unity (URP; Universal Render Pipeline) 사용 권장

절대강좌 유니티 책 공부
- p121 유니티의 주요 이벤트 함수
- p123 이벤트 함수의 호출 순서
- p124 키보드 입력값 받아들이기
  - p124 InputManager
  - p125 GetAxis()
  - p130 GetAxisRaw()
- p130 캐릭터의 이동
  - p132 Vector3 구조체
  - p133 정규화 벡터
  - p135 컴포넌트 캐시 처리
  - p147 벡터의 덧셈 연산
  - p150 벡터의 크기와 정규화
  - p150 Rotate
    - p153 가상 카메라 이동
  - p154 애니메이션
    - p157 애니메이션 클립
    - p159 애니메이션 적용
    - p166 애니메이션 블렌딩
  - p169 무기 장착
  - p172 실시간 그림자
    - p175 Cast Shadows 속성의 Two Sided 옵션에 대해
  - p180 LOD(Level Of Detail)
  - p184 Follow Camera
  - p189 Vector3.Lerp, Vector3.Slerp
  - p192 Vector3.SmoothDamp
  - p195 Target Offset
- 물리 엔진
- p202 RigidBody 컴포넌트
- p206 물리 엔진 속성 설정 - Physics Manager
- p208 Collider 컴포넌트
- p212 충돌 감지 조건
- p215 충돌 이벤트
- p216 Tag 활용
- p219 OnCollisionEnter 콜백 함수
- p221 CompareTag 함수
- p222 총알 발사 로직
- p225 기즈모의 활용
- p231 총알 발사 궤적 효과 만들기 - Trail Renderer
- p239 파티클 활용하기
  - p243 충돌 지점과 법선 벡터
  - p245 쿼터니언
  - p247 GetContact, GetContacts함수의 주의사항
- p252 Scale Factor
- p261 텍스처 변경하기 - Mesh Renderer
- p264 UnityEngine.Random과 System.Random의 혼란
- p273 오디오
- p292 코루틴 함수
  - p303 코루틴의 응용 - 임계치
- p296 블링크 효과
- p299 텍스처 오프셋 변경
- p307 유한 상태 머신(FSM; Finite State Machine)
- p318 Animator 컴포넌트
- p332 NavMeshAgent 컴포넌트
- p336 Find ~ 계열의 함수 주의사항
- p367 Resources 폴더
- p380 특정 레이어 간의 충돌 금지
- p395 대리자 이벤트 구동
  - 함수를 변수로 사용
- p401 이벤트 연결과 해제
- p419 Canvas 컴포넌트
- p458 스크립트에서 버튼 이벤트 처리하기
  - p460 람다식
- p463 TextMesh Pro
  - p467 TextMesh Pro의 한글 처리
  - p533 TMPro using 선언
- p474 생명 게이지 구현
- p503 싱글톤 디자인 패턴
- p507 오브젝트 풀링 디자인 패턴
- p528 스코어 UI 구현
  - p537 playerPrefs를 활용한 스코어 저장
  - p539 playerPrefs의 보안성의 주의 => API 등 활용으로 앱 내 파일 수치와 검사해서 보안 강화 가능
- p541 레이캐스트
  - p541 DrawRay
  - p543 Raycast Hit
- p552 동적 장애물, NavMeshObstacle 컴포넌트
- p556 Off Mesh Link Generation
- p568 전역 조명과 조명 모드
  - p569 Mixed 모드
  - p570 Baked 모드
- p570 라이트매핑
  - Generate Lightmap UVs 옵션(항상 체크)
  - p578 Baked 라이트매핑
  - p584 Area Light(에셋 : [Magic Light Probes: Promo]())
- p585 라이트 프로브
- p604 오클루전 컬링(최적화 작업, 특히 좁은 시야, 1인칭에 필수적)
  - p605 컬링 방식
    - p605 프러스텀 컬링
  - p608 오클루전 컬링 실습
- p664 URP; Universal Render Pipeline
***


### 22-08-02(화)
- XR Interaction toolkit
  - 초기 세팅
    - ![image](https://user-images.githubusercontent.com/85896566/182276900-4100a8b8-89b2-4912-873e-151494baa970.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182275254-2fb0f878-1251-41a2-ac33-fc246e9685f8.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182275432-8fff8f4a-d935-4f5f-bf6a-6185f01d9209.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182277278-2682270a-c19a-4235-83db-7c20ac969159.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182280860-531f8c90-f0bb-4e71-932a-350c17ac5e23.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182281081-c7f086e6-1a5c-489a-b28d-130a55d1b91d.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182281507-786105c1-1103-4f50-8f62-70c3d6bcf8b5.png)
    - 물건 잡기
      - ![image](https://user-images.githubusercontent.com/85896566/182281632-8679297c-bc81-438d-b561-927aa4fa5bcd.png)
      - 콘트롤러에서 스냅할 레이어 마스크 설정
        - ![image](https://user-images.githubusercontent.com/85896566/182283889-fdbde663-ccb2-4eb8-9c13-52fa73b88008.png)
    - 스냅 가능한 오브젝트엔 스크립트, 강체, 콜라이더가 필수
      - ![image](https://user-images.githubusercontent.com/85896566/182281687-85dd36b9-5ca2-44c4-92c2-599ed3aeb297.png)
      - ![image](https://user-images.githubusercontent.com/85896566/182281951-b0896000-51f3-4c33-87ca-1a7c91494fb8.png)
      - ![image](https://user-images.githubusercontent.com/85896566/182282006-b44bbfc9-ec83-4a11-9564-cd8e68374fc7.png)
    - Move
      - 이동을 관장하는 오브젝트(씬 어디에든 배치 가능)
        - ![image](https://user-images.githubusercontent.com/85896566/182286147-a635206d-16b0-48e0-b3c6-9c505c9808d1.png)
      - 에어리어
        - ![image](https://user-images.githubusercontent.com/85896566/182286497-624aa2a9-9878-480b-bc3f-a4bdb38ce44d.png)
      - 앵커
        - ![image](https://user-images.githubusercontent.com/85896566/182286561-db376206-0481-409c-af58-db378e427ed3.png)
     - XR-UI
       - ![image](https://user-images.githubusercontent.com/85896566/182287475-a7062378-8ebd-427e-b4c5-5f2e81d4a384.png)
       - 버튼은 일반 UI에서
         - ![image](https://user-images.githubusercontent.com/85896566/182287676-4f5e7380-37fd-4004-94df-3c7fa2b3e41f.png)
     - Socket Interactor
***


### 22-08-03(수)
- VR 슈팅게임 제작
  - 레이어 설정
    - ![image](https://user-images.githubusercontent.com/85896566/182501377-2f8ba707-8676-4bf5-94e6-2efdf8bf20ee.png)
    - ![image](https://user-images.githubusercontent.com/85896566/182501588-dcf01d5f-f48d-4e1c-b77b-28c1facb9fdd.png)
  - Physics 세팅
    - ![image](https://user-images.githubusercontent.com/85896566/182501798-e18968a8-0d19-4afe-9245-5b5ad3d06a3f.png)
  - 환경 세팅
    - 카메라 위치 동기화
      - ![image](https://user-images.githubusercontent.com/85896566/182502171-7896b972-154f-4298-bbcb-b8504fde2e14.png)
    - 전체적인 분위기 조절(개인 설정)
      - ![image](https://user-images.githubusercontent.com/85896566/182502492-ae246091-f0c8-42fb-aaa1-d63e3d5f0c27.png)
      - ![image](https://user-images.githubusercontent.com/85896566/182502510-933bf252-73df-4268-8c69-53daaa8f75bb.png)
- ★유니티 이벤트 시스템
  - 스크립팅 분리, 리팩토링, 옵저버 디자인 패턴
***


### 22-08-04(목)
- VR 슈팅게임 제작
  - 잡기 방식 변경(누르고 있을 때만(State)/유지(Sticky)
    - ![image](https://user-images.githubusercontent.com/85896566/182741013-a7edd651-b7fb-4c0c-951a-88ba9b25f112.png)
  - 선택했을 때 컨트롤러는 숨김  
    - ![image](https://user-images.githubusercontent.com/85896566/182741246-1fffdda2-818e-4c50-bde9-9bc3e85b431a.png)
  - 시작할 때 들고 있기
    - ![image](https://user-images.githubusercontent.com/85896566/182741407-da55b35e-f38c-4760-b971-5ebdf3431ed9.png)
  - 특정 오브젝트를 위한 광선 제작 하기
    - 라인 렌더러 컴포넌트 좌표계를 부모에게 상속 받는 법(체크 해제)
      - ![image](https://user-images.githubusercontent.com/85896566/182743115-429d0904-41a3-44f1-9f27-2b6462a12f88.png)
***


### 22-08-09(화)
- 절대강좌 유니티
  - p112 ch04.주인공 캐릭터 제작
    - p113
       - 3D 모델을 하이러키 뷰로 가져오고 난 후엔 항상 포지션 값 리셋해주는 습관
       - 유니티 엔진의 개발 방식
         - 컴포넌트 기반 개발 방식(CBD; Component Based Development)
         - 데이터 기반의 개발 방식(DOTS; Data Oriented Technology Stack)
    - p114
      - Transform 컴포넌트는 유일하게 삭제할 수 없다.
    - p
    - p
***

### 22-08-22(월)
오늘 할 일(프로젝트)
- 조원들과 진행 상황 공유
- 발표 후 컨설팅 받기
- 타임라인 체크 후 수정(구체적으로) + 역할 분담
  - 이번 주(프로젝트 內)
    - 외부 디렉토리 접근 -> UI와 연결
    - 퀴즈 패널 로직
    - 자동 채보 로직 기반 커스텀 레벨 디자인
    - 메인/인게임 컨트롤러 변경
    - 게임 중 일시 정지 UI와 동작(패널과 시간 정지)
    - 게임 종료 시 결과 UI(이번 주는 모형 구현 후 간단하게 버튼 전환만) + 박수갈채, 안내 SFX
  - 이번 주(프로젝트 外)
    - 신체 동작 정의(동작별 운동 효과)
    - 설문지 제작
  - 다음 주
    - 동작 별 칼로리 소모량 로직
    - 점수 디자인
    - 3차 UI(Result + Detail)
    - UML 다이어그램 작성

개인 공부
- 최적화 기법(디자인 패턴)
  - 팩토리 메서드 패턴
  - 전략 패턴
  - 오브젝트 풀링
  - 옵저버 패턴
  - 유니티 이벤트 함수
  

- 오전
  - [오일러각(transform.eulerangles)을 사용하여 오브젝트 transform rotation값을 읽거나 수정할때 주의할점](https://learnandcreate.tistory.com/10)
  - Vizualization Objects - FrequencyRing(AudioFrequencyRing.sc) : 생성한 프리팹 위치 수정
  - Vizualization Objects - Ring : 생성될 때 멈추던 에러 
  - ![image](https://user-images.githubusercontent.com/85896566/185834671-62dd9baa-71b6-4360-8624-d31fcc7dfeac.png)

- 오후
  - 모션 모델링 적용
    - ![image](https://user-images.githubusercontent.com/85896566/185851084-f326e318-094d-47f7-a4a6-8138c6f0a6c0.png)
  - 지난 주 개발 내용, 이번 주 내용 조원과 진행상황 공유
  - 외부 디렉토리 연결(NAudio, WWW Class)
  - [Unity UGUI 스크롤뷰(ScrollView) 사용법 간단 정리](https://blog.naver.com/PostView.nhn?blogId=eastfever5&logNo=222095602409)
  - error : 버튼 크기
    - ![image](https://user-images.githubusercontent.com/85896566/185877640-2a1f6979-ab2e-44c1-b675-50aa86a1eadb.png)
  - 취업 컨설팅(1h)
    - 학력 : 최신순
    - 경력 : 관련이 적더라도 적기
    - 대외활동 : 맡았던 직무 자세히(기간이 길수록 ++)
    - 어학 : 관련이 적더라도 적기
    - 자기소개서 트렌드
      - 소제목/두괄식 작성
      - 글자 수는 줄어들고 있음.(틀 마다 500~600자 정도)
      - 오탈자는 타인에게 검수 받기
      - 문장은 간결하게
      - 수동태/과거시제 사용 주의
      - 문어체 사용 -> 구어체 조심
      - 지원동기 : 희망하는 직무와 연관하여 작성
      - 성장과정 : 좌우명/신념/일관적인 모습
      - 입사 후 포부 : 추상적이면 좋지 않다. 구체적으로 이러한 일을 하겠다. 정도
      - 장점 : 꼼꼼함과 의사소통은 너무 많은 사람이 사용하므로 더 구체적인 사연을 예시로 들 것
      - 기술에 대해 어느정도 질문 예상하고 숙지
    - 면접
      - 회사 입구 전 부터 면접이라고 생각하기
      - 잡플래닛 등 면접 후기/질문 참조
    - 자기소개 전개
      - 굳이 실패담은 말하지 않고 장점을 먼저 두괄식으로 제시 후 뒷받침하는 근거를 이야기 한다.
      - 되도록 수치로 말할 수 있는 경험이나 자료가 좋다.
      - 공백기가 많을 경우 솔직하게 대답
      - 되도록 단점을 숨길 수 있는 방향으로 소개
    - 회사 지원 전
      - 인재상 확인
    - 질문
      - 선택적 근무 시간제
      - 포괄임금제(야근)
***


### 22-08-23(화)
오늘 할 일(프로젝트)
- UI 스크롤뷰
  - [Unity UGUI 스크롤뷰(ScrollView) 사용법 간단 정리](https://blog.naver.com/PostView.nhn?blogId=eastfever5&logNo=222095602409)
  - ![image](https://user-images.githubusercontent.com/85896566/186048938-7679ebe9-b52e-4ad5-a59b-f1290fdc6c51.png)
  - ![image](https://user-images.githubusercontent.com/85896566/186048953-c0e3b205-3d91-49fd-b479-0d42ce587d02.png)

- 외부 디렉토리 연결
  - 
***


### 22-08-()
***
### 22-08-()
***
### 22-08-()
***
