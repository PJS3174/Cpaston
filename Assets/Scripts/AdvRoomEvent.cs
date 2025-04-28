using UnityEngine;

// 모험 방별 이벤트 작동
public class AdvRoomEvent : MonoBehaviour
{
    public int food = 0;
    public int water = 0;
    public int medicen = 0;
    public int gun = 0;

    int randInt = 0;

    public GameObject GM;
    public GameObject Character;
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
            food++;
        }
        if (randInt > 3 && randInt <= 7)
        {
            water++;
        }
        if (randInt > 7 && randInt <= 8)
        {
            medicen++;
        }
        if (randInt > 8 && randInt <= 9)
        {
            gun++;
        }
    }

    public void getEmpty()
    {

        Debug.Log("빈 방입니다.");
    }

    public void getEvent()
    {
        if (AdvCharacter.area == "A")
        {
            Debug.Log("구역 A");
            Event.callEvent();
        }
        if (AdvCharacter.area == "B")
        {
            Debug.Log("구역 B");
            Event.callEvent();
        }
        if (AdvCharacter.area == "C")
        {
            Debug.Log("구역 C");
            Event.callEvent();
        }
    }
}
