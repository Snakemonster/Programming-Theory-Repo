using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    public Text AmmoText;
    // Start is called before the first frame update
    private void Start()
    {
        _gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    private void Update()
    {
        AmmoText.text = $"Ammo: {_gun.Ammo}";
    }
}
