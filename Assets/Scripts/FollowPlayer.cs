using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    private void Start()
    {
        transform.position = player.transform.position + offset;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothness);
    }
}
