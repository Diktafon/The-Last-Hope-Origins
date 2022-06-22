
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    GameObject towerObject;
    [SerializeField]
    int towerPrice;


    public GameObject TowerObject
    {
        get
        {

            return towerObject;
        }
    }

    public int TowerPrice
    {
        get
        {
            return towerPrice;
        }
    }
}
