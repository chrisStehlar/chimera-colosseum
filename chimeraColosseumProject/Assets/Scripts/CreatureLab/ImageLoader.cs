using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageGridLoader : MonoBehaviour
{
    public RectTransform contentPanel;
    public GameObject imagePrefab;
    public List<GameObject> sprites = new List<GameObject>();

    void Start()
    {
        foreach (GameObject sprite in sprites)
        {
            GameObject newImage = Instantiate(sprite, contentPanel);
        }

        UpdateContentSize(sprites.Count);

    }
    Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }


    void UpdateContentSize(int itemCount)
    {
        int rows = (itemCount + 2) / 3; 
        float rowHeight = contentPanel.GetComponent<GridLayoutGroup>().cellSize.y + contentPanel.GetComponent<GridLayoutGroup>().spacing.y;
        contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, rows * rowHeight);
    }
}
