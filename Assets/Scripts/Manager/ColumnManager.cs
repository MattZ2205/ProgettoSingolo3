using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    List<GameObject> turrets = new List<GameObject>();

    public void AddTurret(GameObject t)
    {
        turrets.Add(t);
    }

    public Vector3 positionateTurret()
    {
        if (turrets.Count > 0)
        {
            return new Vector3(turrets[turrets.Count - 1].transform.position.x,
                turrets[turrets.Count - 1].transform.position.y + 1,
                turrets[turrets.Count - 1].transform.position.z);
        }
        else
        {
            return new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }

    public void AddPowerUp(GameObject pU, int n)
    {
        turrets.Add(pU);

        for (int i = 0; i < turrets.Count - 1; i++)
        {
            if (turrets[i].GetComponent<Turret>())
            {
                switch (n)
                {
                    case 3:
                        DMGPu(turrets[i].GetComponent<TurretShoot>());
                        break;
                    case 4:
                        RateoPu(turrets[i].GetComponent<TurretShoot>());
                        break;
                    case 5:
                        RangePu(turrets[i].GetComponent<Turret>());
                        break;
                }
            }
        }
    }

    void DMGPu(TurretShoot turret)
    {
        turret.bullet.GetComponent<Bullet>().damage += 2;
    }

    void RateoPu(TurretShoot turret)
    {
        if (turret.rateo > 0.1f)
        {
            turret.rateo -= 0.2f;
        }
    }

    void RangePu(Turret turret)
    {
        turret.range += 5;
    }
}
