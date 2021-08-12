using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    public Text ammoText;
    public Text reloadingText;
    // Start is called before the first frame update
    private void Start()
    {
        // _gun = FindObjectOfType<Gun>();
        reloadingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        ammoText.text = $"Ammo: {_gun.Ammo}";
        reloadingText.gameObject.SetActive(_gun.CurrentGunConditions == GunConditions.FullReloading);
    }
}
