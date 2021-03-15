using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Queue<Bullet> bulletPool = new Queue<Bullet>();
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
        StartCoroutine(LoopCreateBullets());
    }

    IEnumerator LoopCreateBullets()
    {
        while(true)
        {
            CreateBullet(new Vector3(Random.Range(300, Screen.width - 300), Random.Range(100, Screen.height - 100), 0));
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void CreateBullet(Vector3 mousePos)
    {
        Bullet bullet = null;
        if(bulletPool.Count>0)
        {
            bullet = bulletPool.Dequeue();
            bullet.ActiveSelf(true);
        }
        else
        {
            var obj = Instantiate(bulletPrefab);
            bullet = obj.AddComponent<Bullet>();
            bullet.backToPool = () => 
            {
                bullet.ActiveSelf(false);
                bulletPool.Enqueue(bullet);
            };
        }
        var pos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Random.Range(10,15)));
        bullet.SetPos(pos);
        var forward = cam.transform.position + new Vector3(0, 0, -5) - bullet.transform.position;
        bullet.SetForard(forward);
    }
}
