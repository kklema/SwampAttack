using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;

    [SerializeField] private Sprite _sprite;

    [SerializeField] protected Bullet Bullet;

    [SerializeField] private bool _isBuyed = false;

    private int _velocity;

    public Vector3 Velocity => _velocity * Vector3.left * Bullet.Speed;
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