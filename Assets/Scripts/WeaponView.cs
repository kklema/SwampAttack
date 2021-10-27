using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonCLick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonCLick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnButtonCLick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _lable.text = weapon.Lable;
        _icon.sprite = weapon.Icon;
        _price.text = weapon.Price.ToString();
    }
}