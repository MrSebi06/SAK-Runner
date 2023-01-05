using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public float speed = 1f;

    [Header("Sliding Configuration")] 
    public Vector3 slideDirection;
    public float slideAmount = 1.9f;
    
    private Vector3 _startPosition;
    private Coroutine _animationCoroutine;
    

    // Start is called before the first frame update
    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void Open()
    {
        if (!isOpen)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }

            _animationCoroutine = StartCoroutine(DoSlidingOpen());
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = _startPosition + slideAmount * slideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        isOpen = true;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
    
    public void Close()
    {
        if (isOpen)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }
            
            _animationCoroutine = StartCoroutine(DoSlidingClose());
        }
    }
    
    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = _startPosition;
        Vector3 startPosition = transform.position;

        float time = 0;
        isOpen = false;
        
        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
}
