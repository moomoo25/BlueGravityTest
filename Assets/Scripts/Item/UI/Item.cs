using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemTextMeshPro;
    public TextMeshProUGUI valueTextMeshPro;
    public Button itemButton;
    private TextMeshProUGUI itemButtonText;
    public ItemObject itemObject;
    private void Awake()
    {
        
    }
    public virtual void Start()
    {
        itemButton.onClick.AddListener(OnClickItemButton);
        itemButtonText = itemButton.GetComponentInChildren<TextMeshProUGUI>();
    }
  
    public virtual void OnClickItemButton()
    {

    }
    public TextMeshProUGUI GetItemButtonText()
    {
        return itemButtonText;
    }
    public virtual void SetUpItemDetail(ItemObject itemObject_)
    {
        itemObject.id = itemObject_.id;
        itemObject.itemId = itemObject_.itemId;
        itemImage.sprite = itemObject_.itemImage;
        itemTextMeshPro.text = itemObject_.itemText;
        itemObject.itemImage = itemObject_.itemImage;
        itemObject.itemText = itemObject_.itemText;
        itemObject.sellPrice = itemObject_.sellPrice;
        itemObject.buyPrice = itemObject_.buyPrice;
        itemObject.itemMode = itemObject_.itemMode;
        itemObject.isBuyOnce = itemObject_.isBuyOnce;
        //itemObject.isValue = itemObject_.isValue;
        itemObject.value = itemObject_.value;
        if (itemObject.itemMode != itemMode.Consumer)
        {
            valueTextMeshPro.gameObject.SetActive(false);
            return;
        }

        itemButton.gameObject.SetActive(true);
        valueTextMeshPro.text = "x " + itemObject_.value;
    }
    public void UpdateValue(int v)
    {
        itemObject.value = v;
        valueTextMeshPro.text = "x " + v;
        if (v == 0)
            Destroy(this.gameObject);
    }

}
