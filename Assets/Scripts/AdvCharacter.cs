using TMPro;
using UnityEngine;

//모험 캐릭터 이동
public class AdvCharacter : MonoBehaviour
{
    public int move; // 하루에 움직일 수 있는 횟수
    public bool moveLock = false; // 이벤트 중 움직임 잠금
    public string area; // 모험할 구역 -> 이벤트, 아이템 획득 상태가 달라짐
    public bool endCheck = false; // 종료 체크
    public int AdvDay; // 모험 진행 일자

    public GameObject GM;
    AdvRoomEvent advRoomEvent; // 방에서 일어나는 일들
    public Status status; // 캐릭터의 스탯

    public GameObject EL;
    EventList eventList;

    public GameObject advEndPanel;
    public TextMeshProUGUI itemList;

    public CoverSpwan coverSpwaner;

    void Start()
    {
        advRoomEvent = GM.GetComponent<AdvRoomEvent>();
        eventList = EL.GetComponent<EventList>();
    }
    void Update()
    {
        Vector2 pos = transform.position; //오브젝트의 위치 복사
        if (move != 0 && moveLock == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // 오브젝트의 위치에서 좌표 +1
            {
                pos += new Vector2(0f, 1f);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos += new Vector2(0f, -1f);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pos += new Vector2(-1f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                pos += new Vector2(1f, 0f);
            }

            if (pos.x >= 37.5 && pos.x <= 43.5 && pos.y <= 1.5 && pos.y >= -0.5)
            {
                transform.position = pos;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(area);
            Debug.Log("food: " + advRoomEvent.Food + " water: " + advRoomEvent.Water);
        }

        if ((move == 0 && eventList.endState == true && endCheck == false) || (move == 0 && advRoomEvent.endEvent==true && endCheck == false))
        {
            if (AdvDay >= 3) // 탐험 완전 종료
            {
                Debug.Log("All Adventure End");
                endCheck = true;
                advRoomEvent.endEvent = false;

                GameObject selectedCharacter = PanelClick.selectedImg.linkCharacter;

                Status roomStatus = selectedCharacter.GetComponent<Status>();
                Status charStatus = status.GetComponent<Status>();

                roomStatus.hp = charStatus.hp; // 모험 캐릭터의 스탯을 방 캐릭터로 옮김
                roomStatus.adventure = false;

                coverSpwaner.deleteCover(); // 남은 방 삭제
                
                transform.position = new Vector2(37.5f, 0.5f); // 캐릭터 위치 초기화

                showResult();

                advRoomEvent.sendItem(); // 아이템 전달, 초기화
            }
            else
            {
                Debug.Log("Today Adventure End");
                endCheck = true;
                advRoomEvent.endEvent = false;
                showResult();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Normal"))
        {
            advRoomEvent.endEvent = false;
            advRoomEvent.getNormal();
        }
        if (other.CompareTag("Empty"))
        {
            advRoomEvent.endEvent = false;
            advRoomEvent.getEmpty();
        }
        if (other.CompareTag("Event"))
        {
            advRoomEvent.endEvent = false;
            advRoomEvent.getEvent();
            moveLock = true;
        }
        move--;
        Destroy(other.gameObject);
        endCheck = false;
    }

    public void showResult() // 탐험 종료시 보여줄 창
    {
        itemList.text = "Food = " + advRoomEvent.Food + "\tWater = " + advRoomEvent.Water + "\tMedicine = " + advRoomEvent.Medicine + "\nGun = " + advRoomEvent.Gun + "\tResearch = " + advRoomEvent.Research + "\tTool = " + advRoomEvent.Tool + "\nBattery = " +advRoomEvent.Battery;
        advEndPanel.SetActive(true);
    }
}
