using UnityEngine;

public class AdvEnd : MonoBehaviour
{
    public Camera roomCam;  // �� ī�޶�
    public Camera advCam; // ���� ī�޶�
    public GameObject advPanel;
    public GameObject roomPanel;
    public GameObject advGoPanel;

    public GameObject RoomEventManaer;
    public void goRoom()
    {
        RoomEvent roomEvent = RoomEventManaer.GetComponent<RoomEvent>();

        roomCam.enabled = true;
        advCam.enabled = false;
        advPanel.SetActive(false);
        roomPanel.SetActive(true);
        advGoPanel.SetActive(false);

        roomEvent.day += 1;
    }
}
