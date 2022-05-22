using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    bool useStartTime;

    [SerializeField]
    int startYears;
    [SerializeField]
    int startMonths;
    [SerializeField]
    int startDays;
    [SerializeField]
    int startHours;
    [SerializeField]
    int startMinutes;
    [SerializeField]
    int startSeconds;

    float simTime;
    Rigidbody2D rb;

    float StartTime => (float)DateTime.Now
        .AddYears(startYears)
        .AddMonths(startMonths)
        .AddDays(startDays)
        .AddHours(startHours)
        .AddMinutes(startMinutes)
        .AddSeconds(startSeconds)
        .Subtract(DateTime.Now)
        .TotalSeconds;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        simTime += Time.deltaTime;

    }

    void FixedUpdate()
    {
        var y = Mathf.Sin((useStartTime ? simTime + StartTime : Time.time) * speed);
        transform.position = new Vector3(transform.position.x, y);
    }

    void LateUpdate()
    {
        if (!Camera.main) return;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
