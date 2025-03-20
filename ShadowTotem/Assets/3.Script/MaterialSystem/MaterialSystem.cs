using UnityEngine;

public class MaterialSystem : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Texture2D texture;

    private void Start()
    {
        if(texture != null)
        {
            GetComponent<Renderer>().material = material;
            GetComponent<Renderer>().material.SetTexture("_Sprite",texture);
        }
        else
        {
            Debug.Log($"{name}에 texture가 없습니다");
        }
    }
}
