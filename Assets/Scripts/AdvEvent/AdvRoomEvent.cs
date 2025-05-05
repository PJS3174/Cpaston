using UnityEngine;

// 모험 방별 이벤트 작동
public class AdvRoomEvent : MonoBehaviour
{
    public int Food = 0;
    public int Water = 0;
    public int Medicine = 0;
    public int Gun = 0;
    public int Research = 0; //연구자료
    public int Tool = 0; //공구
    public int Battery = 0;

    int randInt = 0;
    public bool endEvent;

    public GameObject GM;
    public GameObject Character;
    public Inventory inventory;

    EventList Event; // 이벤트 방 이벤트 모음
    AdvCharacter AdvCharacter;

    void Start()
    {
        Event = GM.GetComponent<EventList>();
        AdvCharacter = Character.GetComponent<AdvCharacter>(); // 구역을 활용하기 위해 연결
    }
    public void getNormal()
    {
        randInt = Random.Range(0, 10);
        if (randInt <= 3)
        {
            Food++;
        }
        if (randInt > 3 && randInt <= 7)
        {
            Water++;
        }
        if (randInt > 7 && randInt <= 8)
        {
            Medicine++;
        }
        if (randInt > 8 && randInt <= 9)
        {
            Gun++;
        }
        endEvent = true;
    }

    public void getEmpty()
    {
        Debug.Log("빈 방입니다.");
        endEvent = true;
    }

    public void getEvent()
    {
        Event.callEvent();
    }

    public void sendItem() // 탐험 복귀 시 아이템을 전달
    {
        inventory.addItem("Food", Food);
        inventory.addItem("Water", Water);
        inventory.addItem("Medicine", Medicine);
        inventory.addItem("Gun", Gun);
        inventory.addItem("Research", Research);
        inventory.addItem("Tool", Tool);
        inventory.addItem("Battery", Battery);

        Food = 0;
        Water = 0;
        Medicine = 0;
        Gun = 0;
        Research = 0;
        Tool = 0;
        Battery = 0;
    }
}
