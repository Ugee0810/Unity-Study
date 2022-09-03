using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 마우스포인터가 어디에 닿아있는지 캐치하는 것
            RaycastHit hitResult;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitResult))
            {
                //Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
                Bullet bullet = ObjectPool.GetObject(); // 생성하지 않고 풀링함
                Vector3 direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
                //// normalized vs magnitude
                // 
                bullet.transform.position = direction.normalized;
                bullet.Shoot(direction.normalized);
            }
        }
    }
}
