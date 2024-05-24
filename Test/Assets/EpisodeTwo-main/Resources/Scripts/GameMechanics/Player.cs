using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask obstakles;
    [SerializeField] private AudioSource walk;
    
    private bool isRunning;
    public event Action<bool> lookedLeft;
    public event Action<bool> changedRunningStatus;

    void Update()
    {
        bool canMove = !Physics2D.Raycast(transform.position, new Vector2(Input.GetAxis("Horizontal"), 0),2f, obstakles);
        if (canMove)
        {
            float h = Input.GetAxis("Horizontal") * speed;
            if (h != 0 && isRunning == false)
            {
                isRunning = true;
                changedRunningStatus.Invoke(isRunning);
                walk.Play();

                if (h < 0)
                {
                    lookedLeft?.Invoke(true);
                }
                else
                {
                    lookedLeft?.Invoke(false);
                }
            }
            if(h == 0 && isRunning == true)
            {
                isRunning = false;
                changedRunningStatus.Invoke(isRunning);
                walk.Stop();
            }
            transform.Translate(h * Time.deltaTime, 0, 0);

        }
        else if(isRunning == true)
        {
                isRunning = false;
                changedRunningStatus.Invoke(isRunning);
                walk.Stop();
        }

    }
}
