using UnityEngine;
using UnityEngine.UI;

// ���� ������ ��ư�� ������ �� �̺�Ʈ
public class AdvEnd : MonoBehaviour
{
    public Camera roomCam;  // �� ī�޶�
    public Camera advCam; // ���� ī�޶�

    public GameObject advEndCanvas;
    public GameObject roomCanvas;
    public GameObject roomPanel;

    public GameObject stateScreen;
    public GameObject eventScreen;

    public GameObject advScreen;
    public GameObject AdvBtn;

    public GameObject RoomEventManaer;
    public void goRoom()
    {
        RoomEvent roomEvent = RoomEventManaer.GetComponent<RoomEvent>();
        
        roomCam.enabled = true; //ī�޶� ����
        advCam.enabled = false;

        advEndCanvas.SetActive(false); // ���迡�� ����ϴ� ĵ���� �ݱ�

        if (roomEvent.isAdv == true)
        {
            roomCanvas.SetActive(true); // �� ĵ���� ����
            stateScreen.SetActive(true);
            eventScreen.SetActive(false);
            roomPanel.SetActive(false);

            advScreen.SetActive(false);
            AdvBtn.SetActive(false);
        }
        else
        {
            roomCanvas.SetActive(true); // �� ĵ���� ����
            stateScreen.SetActive(true);
            eventScreen.SetActive(false);
            roomPanel.SetActive(false);

            advScreen.SetActive(false);
            AdvBtn.SetActive(true);
        }
        
        roomEvent.day += 1;
    }
}
