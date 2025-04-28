using UnityEngine;

//���� ĳ���� �̵�
public class AdvCharacter : MonoBehaviour
{
    public int move; // �Ϸ翡 ������ �� �ִ� Ƚ��
    public bool moveLock = false; // �̺�Ʈ �� ������ ���
    public string area; // ������ ���� -> �̺�Ʈ, ������ ȹ�� ���°� �޶���
    public bool endCheck = false; // ���� üũ

    public GameObject GM;
    AdvRoomEvent advRoomEvent; // �濡�� �Ͼ�� �ϵ�
    public Status status; // ĳ������ ����

    public GameObject EL;
    EventList eventList;

    public GameObject advEndPanel;

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
            Debug.Log("food: " + advRoomEvent.food + " water: " + advRoomEvent.water);
        }

        if (move == 0 && eventList.endState == true && endCheck == false)
        {
            Debug.Log("Adventure End");
            endCheck = true;
            showResult();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Normal"))
        {
            Debug.Log("Normal");
            advRoomEvent.getNormal();
        }
        if (other.CompareTag("Empty"))
        {
            Debug.Log("Empty");
        }
        if (other.CompareTag("Event"))
        {
            Debug.Log("Event");
            advRoomEvent.getEvent();
            moveLock = true;
        }
        move--;
        Destroy(other.gameObject);
        endCheck = false;
    }

    public void showResult() // Ž�� ����� ������ â
    {
        advEndPanel.SetActive(true);
    }
}
