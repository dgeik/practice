using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    [SerializeField] Transform uiTransform;
    public void ShowClick()
    {
        uiTransform.gameObject.SetActive(!uiTransform.gameObject.activeSelf);
    }
}
