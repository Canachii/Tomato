using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(AudioSource))]
public class Trap : MonoBehaviour
{
    public string tomatoTag = "Player";
    public string areaTag = "Respawn";
    public bool isDrag = true;

    protected static readonly LayerMask TomatoLayer = 1 << 6;

    protected bool IsTriggered;
    private bool _isDragging;
    private bool _isRed;
    private readonly Color _normalColor = Color.white;
    private readonly Color _dragColor = Color.gray;
    private Vector3 _startPosition;
    private Vector3 _lastPosition;
    private Vector3 _screenPoint;
    private Vector3 _offset;

    protected AudioSource Audio;
    protected Animator Anim;
    private SpriteRenderer _sr;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = _startPosition;

        gameObject.SetActive(true);
        IsTriggered = false;
        _isDragging = false;
        isDrag = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isRed = other.CompareTag("Respawn");
        if (other.CompareTag("Player") && !isDrag) Activate(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Respawn")) _isRed = false;
    }

    protected virtual void Activate(Collider2D other)
    {
        IsTriggered = true;
    }

    private void OnMouseOver()
    {
        if (!isDrag) return;

        _sr.color = _isDragging || IsTriggered ? _normalColor : _dragColor;

        Cursor.SetCursor(
            _isDragging
                ? Resources.Load<Texture2D>("Sprites/tile_0139")
                : Resources.Load<Texture2D>("Sprites/tile_0138"), new Vector2(4, 0), CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("Sprites/tile_0137"), new Vector2(4, 0), CursorMode.Auto);

        _sr.color = _normalColor;
    }

    private void OnMouseDown()
    {
        if (!isDrag) return;
        if (IsTriggered) return;

        _isDragging = true;
        Audio.PlayOneShot(Resources.Load<AudioClip>("Sound/drop_004"));

        _lastPosition = transform.position;

        _offset = gameObject.transform.position -
                  Camera.main.ScreenToWorldPoint(
                      new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (!isDrag) return;
        if (IsTriggered) return;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        if (!isDrag) return;
        if (IsTriggered) return;

        _isDragging = false;

        if (_isRed)
        {
            Audio.PlayOneShot(Resources.Load<AudioClip>("Sound/error_006"));
            transform.position = _lastPosition;
            return;
        }

        Audio.PlayOneShot(Resources.Load<AudioClip>("Sound/drop_001"));
    }
}