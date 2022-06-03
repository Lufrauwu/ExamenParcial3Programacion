using UnityEngine;


public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialScreen = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tutorialScreen.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _tutorialScreen.SetActive(false);
    }
}