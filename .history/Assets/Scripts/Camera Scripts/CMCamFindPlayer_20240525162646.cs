using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CMCamFindPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = Player.Instance.F;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
