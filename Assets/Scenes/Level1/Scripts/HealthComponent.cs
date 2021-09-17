using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{
    private Canvas canvas;
    private float _healthPercent;
    private float _maxHealth;
    private float _onePercentHealth;
    //private string _text;
    //private int _textSize = 16;
    //private Font _textFont;
    //private Color _textColor = Color.red;
   // private float _textHeight = 2.15f;
    private bool _visible;

    [SerializeField]
    private GameObject healthComponent;
   


    [SerializeField]
    private Transform leftPos;
    [SerializeField]
    private Transform nullHealth;
    [SerializeField]
    private Transform health;


    public float Health
    {
        get { return _healthPercent; }
    }

    public void SetDamage(float damage)
    {
        var damagePersent = (damage * 100) / _maxHealth;
        _healthPercent -= damagePersent;
    }

    public void SetHealth(float health)
    {
        _maxHealth = health;
        _healthPercent = 100;
        _onePercentHealth = _maxHealth / 100;
    }

    public void Visible(bool visible)
    {
        _visible = visible;
    }

    void Awake()
    {
        _visible = true;
    }

    private void Update()
    {

        healthComponent.active = _visible;

        health.localScale = new Vector3(_healthPercent / 100, health.localScale.y, health.localScale.z);
        var delta = nullHealth.position - leftPos.position;
        health.position += delta;
    }

   /*
    void OnGUI()
    {
        GUI.depth = 9999;
        GUIStyle style = new GUIStyle();
        style.fontSize = _textSize;
        style.richText = true;
        if (_textFont)
            style.font = _textFont;
        style.normal.textColor = _textColor;
        style.alignment = TextAnchor.MiddleCenter;

        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + _textHeight, transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        screenPosition.y = Screen.height - screenPosition.y;

        GUI.Label(new Rect(screenPosition.x, screenPosition.y, 0, 0), _text, style);
    }

    */

}
