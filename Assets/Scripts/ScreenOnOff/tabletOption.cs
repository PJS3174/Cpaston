using UnityEngine;
using UnityEngine.UI;

public class tabletOption : MonoBehaviour
{
    public Button StateBtn;
    public Button FoodBtn;
    public Button EventBtn;
    public Button AdvBtn;

    public GameObject StateScreen;
    public GameObject FoodScreen;
    public GameObject EventScreen;
    public GameObject AdvScreen;

    void Start()
    {
        StateBtn.onClick.AddListener(StateClick);
        FoodBtn.onClick.AddListener(FoodClick);
        EventBtn.onClick.AddListener(EventClick);
        AdvBtn.onClick.AddListener(AdvClick);

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
}
