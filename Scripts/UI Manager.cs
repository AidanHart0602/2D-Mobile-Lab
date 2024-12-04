using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI instance is NULL");
            }
            return _instance;
        }
    }
    private int _currentItem;
    private int _currentItemPrice;
    public GameObject ShopUI;
    public TMP_Text gemShopCountText;
    public TMP_Text gemCounter;
    public Image selectionBar;
    [SerializeField]
    private Player _player;

    public GameObject[] healthBar;
    private void Awake()
    {
        _instance = this;
    }
    private void Update()
    {
        GemCount(_player.Loot);
    }

    public void GemCount(int gems)
    {
        gemCounter.text = "" + gems;
        gemShopCountText.text = gems + "G";
    }
    public void HealthBits(int health)
    {
        healthBar[health].SetActive(false);
    }

    public void SelectionBar(int Button)
    {
        switch (Button)
        {
            case 0:
                Debug.Log("Flame sword selected");
                selectionBar.rectTransform.anchoredPosition = new Vector2(-51, 46);
                _currentItem = 0;
                _currentItemPrice = 300;
                break;
            case 1:
                Debug.Log("Jump Boots selected");
                selectionBar.rectTransform.anchoredPosition = new Vector2(-51, 0);

                _currentItem = 1;
                _currentItemPrice = 200;
                break;
            case 2:
                Debug.Log("Key selected");
                selectionBar.rectTransform.anchoredPosition = new Vector2(-51, -46);
                _currentItem = 2;
                _currentItemPrice = 100;
                break;
            default:
                break;
        }
    }

    public void BuyButton()
    {
        if (_player.Loot >= _currentItemPrice)
        {
            _player.Loot -= _currentItemPrice;
            Debug.Log("Player now has " + _player.Loot + "gems");
            GemCount(_player.Loot);
            if(_currentItem == 2)
            {
                GameManager.instance.boughtKey = true;
            }
        }

        else if (_player.Loot < _currentItemPrice)
        {
            Debug.Log("If you can't buy anything, GET OUT");
            ShopUI.SetActive(false);
        }
    }
}
