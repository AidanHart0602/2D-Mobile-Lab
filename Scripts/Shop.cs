using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject _merchantUI;
    private AdManager _adManager;
    private void Start()
    {
        _adManager = FindFirstObjectByType<AdManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.Instance.GemCount(player.Loot);
            }
            _merchantUI.SetActive(true);
            _adManager.LoadAd();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _merchantUI.SetActive(false);
        }
    }
}
