using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageGridLoader : MonoBehaviour
{
    public RectTransform contentPanel;
    public GameObject imagePrefab;

    void Start()
    {
        List<Sprite> images = LoadImages();
        foreach (Sprite image in images)
        {
            GameObject newImage = Instantiate(imagePrefab, contentPanel);
            newImage.GetComponent<Image>().sprite = image;
        }

        int testNum = 20;
        //this is for testing
        for (int i = 0; i < testNum; i++) {
            GameObject newImage = Instantiate(imagePrefab, contentPanel);
            newImage.GetComponent<Image>().color = RandomColor();
        }

        UpdateContentSize(images.Count+testNum);

    }
    Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
    List<Sprite> LoadImages()
    {
        return new List<Sprite>();
    }

    void UpdateContentSize(int itemCount)
    {
        int rows = (itemCount + 2) / 3; 
        float rowHeight = contentPanel.GetComponent<GridLayoutGroup>().cellSize.y + contentPanel.GetComponent<GridLayoutGroup>().spacing.y;
        contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, rows * rowHeight);
    }
}
