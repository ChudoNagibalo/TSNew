using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FPGame.Hyinya;
using FPGame.Enemy.Base;
using System;
using Unity.VisualScripting;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro _textMesh;
    private EnemyBase enemyBase;
    private float _disappearTimer;
    private Color _textColor;
    private static bool stopPopup = true;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
    }


    public static DamagePopup Create(Vector2 position, int damageAmount)
    {
     
        Transform damagePopupTransform = Instantiate(GameAssets.i.damagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    public void Setup(int damageAmount)
    {
        _textMesh.SetText(damageAmount.ToString());
        _textColor = _textMesh.color;
        _disappearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 5f;
        transform.position += new Vector3(0, moveYSpeed, 0) * Time.deltaTime;

        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            _textColor.a -= disappearSpeed * Time.deltaTime;
            _textMesh.color = _textColor;
            if(_textColor.a < 0 )
            {
                Destroy(gameObject);
            }
        }
    }
}
