using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 5f;
    [SerializeField] private float yOffset = 0f;
    public Transform target;

    private void Awake()
    {
        target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
