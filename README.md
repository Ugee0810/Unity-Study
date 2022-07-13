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
 - 위키북스 - 절대강좌 유니티
 ### 22-07-14(Thu)
 - 멀티쓰레드
 - 

### 22-07-()
 - 
 - 

### 22-07-()
 - 
 - 

### 22-07-()
 - 
 - 

### 22-07-()
 - 
 - 
 - 
