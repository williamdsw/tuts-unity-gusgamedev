using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] private Sprite[] healthBarSprites;
    [SerializeField] private Image healthBarUI;

    // Cached
    private Player player;

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update () 
    {
        // Check and cancels
        if (healthBarSprites.Length == 0 || !healthBarUI || !player) { return; }

        healthBarUI.sprite = healthBarSprites[player.GetHealth ()];
    }   
}