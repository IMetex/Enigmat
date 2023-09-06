using UnityEngine;
using UnityEngine.UI;

public class indicator_left_click : MonoBehaviour
{
    [Header("Ability 2")]
    public Image abilityImage;
    public Text abilityText2;
    public KeyCode ability2Key;
    public float ability2Cooldown = 7;
    public Canvas ability2Canvas;
    public Image ability2RangeIndicator;
    public float maxAbility2Distance = 7; // maxAbility2Distance tanýmlandý

    private bool isAbility2Cooldown = false;
    private float currentAbility2Cooldown;

    private RaycastHit hit;
    private Ray ray;



    //------------------

    public GameObject indicatorPrefab, lastSpawn; // Gösterge için kullanýlacak prefab
    private GameObject temp;
    private bool isSpawned = false;
    public float yOffset = 0.2f;
    Vector3 worldPosition;
    void Start()
    {
        // Ýlk baþta indikatörü pasif yap
        ability2RangeIndicator.enabled = false;
        ability2Canvas.enabled = false;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage, abilityText2);
        ControlInput();
    }

   

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;
                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
    private void ControlInput()
    {
        if (Input.GetMouseButton(1) &&  !isAbility2Cooldown)
        {
            currentAbility2Cooldown = ability2Cooldown;
            ability2Canvas.enabled = true;
            ability2RangeIndicator.enabled = true;
        }

        // Büyü yeteneði kullanýmýný bitirdiðinizde
        

        if (!isSpawned)
        {
            worldPosition = MousePosWorld();
            Create(worldPosition);

        }
        // Büyü yeteneði kullanýlacaðýnda (örneðin, fare sol týklamada)
        if (isSpawned)
        {
            temp.transform.position = MousePosWorld();
             Vector3 asdasdf= transform.position;
            asdasdf.y /= 2;
            ability2Canvas.transform.position = asdasdf;


            ability2RangeIndicator.transform.position = temp.transform.position;
        }

        if (Input.GetMouseButtonUp(1) && ability2Canvas.enabled)
        {
            EndIndicate();
        }
    }

    public void EndIndicate()
    {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
            ability2Canvas.enabled = false;
            ability2RangeIndicator.enabled = false;
        
        Instantiate(lastSpawn, temp.transform.position, Quaternion.identity);
    }

    private Vector3 MousePosWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = maxAbility2Distance; // Uzaklýðý ayarlayýn
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }

    private GameObject Create(Vector3 worldPos)
    {
        isSpawned = true;
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        return temp;
    }
}

