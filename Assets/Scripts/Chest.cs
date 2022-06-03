using UnityEngine;

public class Chest : MonoBehaviour
{
    private SpriteRenderer _renderer = default;
    private Sprite _openChest, _closedChest = default;
    private bool _enterTrigger = false;
    private int _starsSpawned = 30;
    public Transform _chest= default;
    public Rigidbody2D _stars = default;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _closedChest = Resources.Load<Sprite>("chest-1");
        _openChest = Resources.Load<Sprite>("chest-2");
        _renderer.sprite = _closedChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enterTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enterTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _enterTrigger)
        {
            _renderer.sprite = _openChest;
            for (int i = 0; i < _starsSpawned; i++)
            {
                Rigidbody2D starsInstance = Instantiate(_stars, _chest.position, _chest.rotation);
                starsInstance.AddForce(_chest.up * 800f);
            }
        }
    }
}
