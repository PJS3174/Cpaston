using UnityEngine;

// ���� �溰 �̺�Ʈ �۵�
public class AdvRoomEvent : MonoBehaviour
{
    public int food = 0;
    public int water = 0;
    public int medicen = 0;
    public int gun = 0;

    int randInt = 0;

    public GameObject GM;
    public GameObject Character;
    EventList Event; // �̺�Ʈ �� �̺�Ʈ ����
    AdvCharacter AdvCharacter;
    void Start()
    {
        Event = GM.GetComponent<EventList>();
        AdvCharacter = Character.GetComponent<AdvCharacter>(); // ������ Ȱ���ϱ� ���� ����
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

        Debug.Log("�� ���Դϴ�.");
    }

    public void getEvent()
    {
        if (AdvCharacter.area == "A")
        {
            Debug.Log("���� A");
            Event.callEvent();
        }
        if (AdvCharacter.area == "B")
        {
            Debug.Log("���� B");
            Event.callEvent();
        }
        if (AdvCharacter.area == "C")
        {
            Debug.Log("���� C");
            Event.callEvent();
        }
    }
}
