﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

    Camera m_Camera;

    // Use this for initialization
    void Start () {
        m_Camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
