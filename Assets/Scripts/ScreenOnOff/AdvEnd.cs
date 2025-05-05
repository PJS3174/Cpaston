using UnityEngine;
using UnityEngine.UI;

// 모험 끝내기 버튼을 눌렀을 때 이벤트
public class AdvEnd : MonoBehaviour
{
    public Camera roomCam;  // 방 카메라
    public Camera advCam; // 모험 카메라

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
        
        roomCam.enabled = true; //카메라 변경
        advCam.enabled = false;

        advEndCanvas.SetActive(false); // 모험에서 사용하는 캔버스 닫기

        if (roomEvent.isAdv == true)
        {
            roomCanvas.SetActive(true); // 방 캔버스 설정
            stateScreen.SetActive(true);
            eventScreen.SetActive(false);
            roomPanel.SetActive(false);

            advScreen.SetActive(false);
            AdvBtn.SetActive(false);
        }
        else
        {
            roomCanvas.SetActive(true); // 방 캔버스 설정
            stateScreen.SetActive(true);
            eventScreen.SetActive(false);
            roomPanel.SetActive(false);

            advScreen.SetActive(false);
            AdvBtn.SetActive(true);
        }
        
        roomEvent.day += 1;
    }
}
