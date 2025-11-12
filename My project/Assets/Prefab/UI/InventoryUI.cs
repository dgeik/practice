using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform panelTransform;

    void Start()
    {
        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Button deleteBtn = panelTransform.GetChild(i).GetChild(2).GetComponent<Button>();
            var slot = panelTransform.GetChild(i);
            Button slotBtn = slot.GetComponent<Button>();


            deleteBtn.gameObject.SetActive(false);

            deleteBtn.onClick.RemoveAllListeners();
            deleteBtn.onClick.AddListener(() =>
            {
                PlayerData.inventory.RemoveAt(i-(int)PlayerData.inventory.getCapacity);
                deleteBtn.gameObject.SetActive(false);
                UpdateUI();
            });

            slotBtn.onClick.RemoveAllListeners();
            slotBtn.onClick.AddListener(() =>
            {
                if (slot.GetComponentInChildren<Image>().sprite != null)
                {
                    if (deleteBtn.gameObject.activeSelf) deleteBtn.gameObject.SetActive(false);
                    else deleteBtn.gameObject.SetActive(true);
                }
                UpdateUI();
            });
        }
    }
    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < PlayerData.inventory.getCapacity; i++)
        {
            var iconImage = panelTransform.GetChild(i).GetComponentInChildren<Image>();
            var countText = panelTransform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();


            if (i < PlayerData.inventory.getInventory.Count)
            {
                var item = PlayerData.inventory.getInventory[i].item;
                var count = PlayerData.inventory.getInventory[i].count;

                iconImage.sprite = item.iconItem;
                iconImage.enabled = true;
                countText.text = count > 1 ? count.ToString() : "";

            }
            else
            {
                iconImage.sprite = null;
                iconImage.enabled = false;
                countText.text = "";
            }
        }
    }
}
