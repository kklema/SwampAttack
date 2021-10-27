using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected Bullet Bullet;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _sprite;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}
