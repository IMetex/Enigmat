using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab, tempObject; // Gösterge için kullanılacak prefab
    private GameObject temp;
    private bool isSpawned = false;
    public float yOffset = 0.2f;
    public GameObject particleCircle;
    Vector3 worldPosition;
    private void Start()
    {

    }
    void Update()
    {
        // Büyü yeteneği kullanılacağında (örneğin, fare sol tıklamada)
        ControlInput();

    }

    private void ControlInput()
    {
        if (Input.GetMouseButton(1))
        {
            isSpawned = false;
        }

        // Büyü yeteneği kullanımını bitirdiğinizde


        if (!isSpawned)
        {
            worldPosition = MousePosWorld();
            Create(worldPosition);

        }
        // Büyü yeteneği kullanılacağında (örneğin, fare sol tıklamada)
        if (isSpawned)
        {
            temp.transform.position = MousePosWorld();
            Debug.Log("isSpawned" + isSpawned);
        }

        if (Input.GetMouseButtonUp(1))
        {
            EndIndicate();
        }
    }

    public void EndIndicate()
    {

        Instantiate(tempObject, temp.transform.position, Quaternion.identity);
    }

    private Vector3  MousePosWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Uzaklığı ayarlayın
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }

    private GameObject Create(Vector3 worldPos)
    {
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        isSpawned = true;
        return temp;
    }
    private bool isFalling = true; // Alev topu düşüyor mu?

    void Updat()
    {
        if (isFalling && transform.position.y <= 0f)
        {
            // Alev topu yere düştü, burada kaybolabilir veya başka bir işlem yapabilirsiniz.
            Destroy(gameObject); // Alev topunu yok et
        }
    }

    // Alev topu bir şeye çarptığında çalışacak kod
    void OnTriggerEnter(Collider other)
    {
        if (isFalling)
        {
            if (other.tag == "Dusman")
            {
                // Düşmanı vurduğunuzu işaretlemek veya zarar vermek için burada kod ekleyebilirsiniz.
                Debug.Log("Düşman vuruldu!");

                // Düşmanı yok etmek veya zarar vermek için burada kod ekleyebilirsiniz.
            }

            // Alev topunu yok etmek için kod
            Destroy(gameObject);
        }
    }
}


