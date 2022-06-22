using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerManager : Loader<TowerManager>
{
    public TowerBtn towerBtnPressed {get; set;}

    // Give reference of tower tilemap layout
    [SerializeField]
    private GridLayout towerGrigLayout;



    void Start()
    {
        
    }

    void Update()
    {
        //�������� ���� ������ ���� ������
        if (Input.GetMouseButtonDown(0))
        {
            //����� ����������� �������
            if (Camera.main != null)
            {
                //���������� ������� ������� ��������� ����������
                Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //��������� ������� z = 0
                mousePoint.z = 0;

                RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

                //�������� ������������� ����� ��� ���������� �����
                if (hit.collider != null && hit.collider.CompareTag("TowerSide"))
                {
                    
                    hit.collider.tag = "TowerSideFull";
                    
                    //����� ������ ���������� �����
                    PlaceTower(mousePoint);                                
                }            
            }

           
        }
    }

    // Place Tower Metod
    public void PlaceTower(Vector3 mousePoint)
    {
        // convert mouse click's position to Grid position
        Vector3Int cellPosition = towerGrigLayout.WorldToCell(mousePoint);

        // Check, if can place tower in this place
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            int mOstatok = Manager.Instance.subtractMoney(0);
            if (mOstatok >= towerBtnPressed.TowerPrice) 
            { 
                // Check, what the tower instantiate and do it
                GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
                newTower.transform.position = cellPosition;
                BuyTower(towerBtnPressed.TowerPrice);
            }
        }
        
    }

    public void BuyTower(int price)
    {
        Manager.Instance.subtractMoney(price);
    }

    public void SelectedTower(TowerBtn towerSelected)
    {
        

       if (towerSelected.TowerPrice <= Manager.Instance.TotalMoney)
            {
                towerBtnPressed = towerSelected;
            }
       
        
        Debug.Log("Pressed" + towerBtnPressed.gameObject);
    }

}