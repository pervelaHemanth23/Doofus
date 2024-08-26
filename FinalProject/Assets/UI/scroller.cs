using UnityEngine;
using UnityEngine.UI;

public class scroller : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] float offset_x, offset_y;

    private void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(offset_x, offset_y) * Time.deltaTime, image.uvRect.size);
    }
}
