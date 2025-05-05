using UnityEngine;

// ������ �̹����� ĳ���� ������ ���� ĳ���Ϳ� �Ѱ���
public class AdvGo : MonoBehaviour
{
    public GameObject targetObject; // ���� ĳ����
    public Camera roomCam;  // �� ī�޶�
    public Camera advCam; // ���� ī�޶�
   
    public RoomEvent RoomManager; //���� ���¸� �ޱ� ����
    public CoverSpwan coverSpwaner;

    public bool canSend = false;

    public void checkSend()
    {
        if (PanelClick.selectedImg == null || SelectMap.selectedImg == null)
        {
            Debug.Log("���õ� �̹��� ����");
            canSend = false;
        }
        else
        {
            canSend = true;
            SendStatus();
        }
    }

    public void SendStatus()
    {
        GameObject selectedCharacter = PanelClick.selectedImg.linkCharacter; // ���õ� ĳ���� �̹���
        GameObject seledtedMap = SelectMap.selectedImg.gameObject;

        Status roomStatus = selectedCharacter.GetComponent<Status>(); // ������ ĳ���� ����
        Status advStatus = targetObject.GetComponent<Status>(); // ���� �� ĳ���� ����

        AdvCharacter AdvMove = targetObject.GetComponent<AdvCharacter>();

        string selectedMap = SelectMap.selectedMap; // ���õ� �� ����

        advStatus.CharacterName = roomStatus.CharacterName;
        advStatus.hp = roomStatus.hp;
        advStatus.mental = roomStatus.mental;
        advStatus.adventure = true;
        roomStatus.adventure = true;

        AdvMove.move = 2;
        AdvMove.area = selectedMap;
        
        advCam.enabled = true;
        roomCam.enabled = false;

        if (RoomManager.isAdv == false)
        {
            AdvMove.AdvDay = 1; //���� ������ 1�� �ʱ�ȭ;
            coverSpwaner.setCover();
        }

        Debug.Log("���� �Ϸ�");
    }
}
