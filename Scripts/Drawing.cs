using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawing : MonoBehaviour
{
    private RectTransform rectTransform;
    private RawImage rawImage;
    private Texture2D canvas;
    private StartOptions startOptions;

    private List<Vector3> points = new List<Vector3>();

    private Vector3 _bottomLeft = Vector3.zero;
    private Vector3 _topRight = Vector3.zero;

    private int _width = 0;
    private int _height = 0;

    private void Start()
    {
        startOptions = FindObjectOfType<StartOptions>();

        rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            GetWorldCorners();
        }

        rawImage = GetComponent<RawImage>();

        if (rawImage != null)
        {
            CreateTexture();
        }
    }

    private void Update()
    {
        if (rectTransform != null)
        {
            if (rawImage != null)
            {
                HandleInput();
            }
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Vector2Int mousePos = Vector2Int.zero;
            ConvertMousePosition(ref mousePos);

            if (MouseIsInBounds(mousePos))
            {
                PaintTexture(mousePos, Color.black);
            }
            Debug.Log(mousePos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startOptions.Redirect(points, _width / 2, _height / 2);
            startOptions.IsRunning = true;
            points.Clear();
        }
    }

    private void PaintTexture(Vector2Int pos, Color color)
    {
        canvas.SetPixel(pos.x, pos.y, color);
        points.Add(new Vector3(pos.x, pos.y));
        canvas.Apply(false);
    }

    private bool MouseIsInBounds(Vector2Int mousePos)
    {
        if (mousePos.x >= 0 && mousePos.x < _width)
        {
            if (mousePos.y >= 0 && mousePos.y < _height)
            {
                return true;
            }
        }
        return false;
    }

    private void ConvertMousePosition(ref Vector2Int mouseOut)
    {
        mouseOut.x = Mathf.RoundToInt(Input.mousePosition.x - _bottomLeft.x);
        mouseOut.y = Mathf.RoundToInt(Input.mousePosition.y - _bottomLeft.y);
    }

    private void CreateTexture()
    {
        _width = Mathf.RoundToInt(_topRight.x - _bottomLeft.x);
        _height = Mathf.RoundToInt(_topRight.y - _bottomLeft.y);
        canvas = new Texture2D(_width, _height);
        rawImage.texture = canvas;
    }

    private void GetWorldCorners()
    {
        if (rectTransform != null)
        {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            _bottomLeft = corners[0];
            _topRight = corners[2];
        }
    }
}