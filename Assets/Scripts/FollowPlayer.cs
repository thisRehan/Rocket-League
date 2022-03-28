using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        transform.LookAt(player.transform.position);
    }
    
}
