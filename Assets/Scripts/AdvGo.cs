using UnityEngine;

// ������ �̹����� ĳ���� ������ ���� ĳ���Ϳ� �Ѱ���
public class AdvGo : MonoBehaviour
{
    public GameObject targetObject; // ���� ĳ����
    public Camera roomCam;  // �� ī�޶�
    public Camera advCam; // ���� ī�޶�
   
    public RoomEvent RoomManager; //���� ���¸� �ޱ� ����
    public CoverSpwan coverSpwaner;

    void Start()
    {
        roomCam.enabled = true;
        advCam.enabled = false;
    }
    public void SendStatus()
    {
        if (PanelClick.selectedImg == null)
        {
            Debug.Log("���õ� �̹��� ����");
            return;
        }

        GameObject selectedCharacter = PanelClick.selectedImg.linkCharacter; // ���õ� ĳ���� �̹���
        GameObject seledtedMap = SelectMap.selectedImg.gameObject; 

        Status roomStatus = selectedCharacter.GetComponent<Status>(); // ������ ĳ���� ����
        Status advStatus = targetObject.GetComponent<Status>(); // ���� �� ĳ���� ����

        AdvCharacter AdvMove = targetObject.GetComponent<AdvCharacter>();

        string selectedMap = SelectMap.selectedMap; // ���õ� �� ����

        advStatus.name = roomStatus.name;
        advStatus.hp = roomStatus.hp;
        advStatus.mental = roomStatus.mental;
        advStatus.adventure = true;
        roomStatus.adventure = true;

        AdvMove.move = 2;
        AdvMove.area = selectedMap;

        advCam.enabled = true;
        roomCam.enabled = false;

        if (RoomManager.isAdv == false) {
            coverSpwaner.setCover();
        }

        Debug.Log("���� �Ϸ�");
    }
}
