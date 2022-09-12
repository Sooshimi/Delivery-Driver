using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay;

    bool hasPackage;
    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }
}
