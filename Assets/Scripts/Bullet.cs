using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public Action backToPool;
    public float timer;
    private float LIFE_TIME_LIMIT = 2f;
    private Transform m_selfTrans;
    private GameObject m_selfGo;

    private void Awake()
    {
        m_selfGo = gameObject;
        m_selfTrans = transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= LIFE_TIME_LIMIT)
        {
            if (null != backToPool)
                backToPool();

            timer = 0;
        }
    }

    public void ActiveSelf(bool active)
    {
        m_selfGo.SetActive(active);
    }

    public void SetPos(Vector3 pos)
    {
        m_selfTrans.position = pos;
    }

    public void SetForard(Vector3 forward)
    {
        m_selfTrans.forward = forward;
    }
}
