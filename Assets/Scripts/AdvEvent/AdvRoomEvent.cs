using UnityEngine;

// ���� �溰 �̺�Ʈ �۵�
public class AdvRoomEvent : MonoBehaviour
{
    public int Food = 0;
    public int Water = 0;
    public int Medicine = 0;
    public int Gun = 0;
    public int Research = 0; //�����ڷ�
    public int Tool = 0; //����
    public int Battery = 0;

    int randInt = 0;
    public bool endEvent;

    public GameObject GM;
    public GameObject Character;
    public Inventory inventory;

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
        Debug.Log("�� ���Դϴ�.");
        endEvent = true;
    }

    public void getEvent()
    {
        Event.callEvent();
    }

    public void sendItem() // Ž�� ���� �� �������� ����
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
