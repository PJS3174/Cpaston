using TMPro;
using UnityEngine;

//���� ĳ���� �̵�
public class AdvCharacter : MonoBehaviour
{
    public int move; // �Ϸ翡 ������ �� �ִ� Ƚ��
    public bool moveLock = false; // �̺�Ʈ �� ������ ���
    public string area; // ������ ���� -> �̺�Ʈ, ������ ȹ�� ���°� �޶���
    public bool endCheck = false; // ���� üũ
    public int AdvDay; // ���� ���� ����

    public GameObject GM;
    AdvRoomEvent advRoomEvent; // �濡�� �Ͼ�� �ϵ�
    public Status status; // ĳ������ ����

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
        Vector2 pos = transform.position; //������Ʈ�� ��ġ ����
        if (move != 0 && moveLock == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // ������Ʈ�� ��ġ���� ��ǥ +1
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
            if (AdvDay >= 3) // Ž�� ���� ����
            {
                Debug.Log("All Adventure End");
                endCheck = true;
                advRoomEvent.endEvent = false;

                GameObject selectedCharacter = PanelClick.selectedImg.linkCharacter;

                Status roomStatus = selectedCharacter.GetComponent<Status>();
                Status charStatus = status.GetComponent<Status>();

                roomStatus.hp = charStatus.hp; // ���� ĳ������ ������ �� ĳ���ͷ� �ű�
                roomStatus.adventure = false;

                coverSpwaner.deleteCover(); // ���� �� ����
                
                transform.position = new Vector2(37.5f, 0.5f); // ĳ���� ��ġ �ʱ�ȭ

                showResult();

                advRoomEvent.sendItem(); // ������ ����, �ʱ�ȭ
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

    public void showResult() // Ž�� ����� ������ â
    {
        itemList.text = "Food = " + advRoomEvent.Food + "\tWater = " + advRoomEvent.Water + "\tMedicine = " + advRoomEvent.Medicine + "\nGun = " + advRoomEvent.Gun + "\tResearch = " + advRoomEvent.Research + "\tTool = " + advRoomEvent.Tool + "\nBattery = " +advRoomEvent.Battery;
        advEndPanel.SetActive(true);
    }
}
