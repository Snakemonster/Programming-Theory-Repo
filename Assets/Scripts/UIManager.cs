using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Player _player;
    public Text ammoText;
    public Text reloadingText;
    // Start is called before the first frame update
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        reloadingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        ammoText.text = $"Ammo: {_player._currentGun.GetComponent<Gun>().Ammo}";
        reloadingText.gameObject.SetActive(_player._currentGun.GetComponent<Gun>().CurrentGunConditions == GunConditions.FullReloading);
    }
}
