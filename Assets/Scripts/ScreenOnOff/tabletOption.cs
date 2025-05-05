using UnityEngine;
using UnityEngine.UI;

public class tabletOption : MonoBehaviour
{
    public Button StateBtn;
    public Button FoodBtn;
    public Button EventBtn;
    public Button AdvBtn;

    public Button NextBtn;
    public Button PreviousBtn;

    public GameObject StateScreen;
    public GameObject FoodScreen;
    public GameObject EventScreen;
    public GameObject AdvScreen;

    public RoomEvent RoomManager;
    public GameObject advCharacter;
    
    public GameObject RoomCanvas;
    public Camera roomCam;  // 방 카메라
    public Camera advCam; // 모험 카메라

    public GameObject AdvOn;

    void Start()
    {
        StateBtn.onClick.AddListener(StateClick);
        FoodBtn.onClick.AddListener(FoodClick);
        EventBtn.onClick.AddListener(EventClick);
        AdvBtn.onClick.AddListener(AdvClick);

        NextBtn.onClick.AddListener(NextClick);
        PreviousBtn.onClick.AddListener(PreviousClick);
    }

    public void StateClick()
    {
        StateScreen.SetActive(true);
        FoodScreen.SetActive(false);
        EventScreen.SetActive(false);
        AdvScreen.SetActive(false);
    }

    public void FoodClick()
    {
        StateScreen.SetActive(false);
        FoodScreen.SetActive(true);
        EventScreen.SetActive(false);
        AdvScreen.SetActive(false);
    }

    public void EventClick()
    {
        StateScreen.SetActive(false);
        FoodScreen.SetActive(false);
        EventScreen.SetActive(true);
        AdvScreen.SetActive(false);
    }

    public void AdvClick()
    {
        StateScreen.SetActive(false);
        FoodScreen.SetActive(false);
        EventScreen.SetActive(false);
        AdvScreen.SetActive(true);
    }

    public void NextClick()
    {
        if (StateScreen.activeSelf)
        {
            FoodClick();
        }
        else if (FoodScreen.activeSelf)
        {
            EventClick();
        }
        else if (EventScreen.activeSelf)
        {
            if (RoomManager.isAdv == true)
            {
                AdvCharacter advCha = advCharacter.GetComponent<AdvCharacter>();
                advCha.move = 2;
                advCha.AdvDay += 1;

                RoomCanvas.SetActive(false);
                advCam.enabled = true;
                roomCam.enabled = false;
            }
            else
            {
                AdvClick();
            }
        }
        else if (AdvScreen.activeSelf)
        {
            AdvGo advGo = AdvOn.GetComponent<AdvGo>();
            advGo.checkSend();
            if (advGo.canSend == true)
            {
                RoomCanvas.SetActive(false);
            }
        }
    }
    public void PreviousClick()
    {
        if (AdvScreen.activeSelf)
        {
            EventClick();
        }
        else if (EventScreen.activeSelf)
        {
            FoodClick();
        }
        else if (FoodScreen.activeSelf)
        {
            StateClick();
        }
    }
}
