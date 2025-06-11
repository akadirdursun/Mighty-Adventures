using UnityEngine;

namespace MightyAdventures.Gameplay
{
    public class GameZone : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private RectTransform leftOffsetRectTransform;
        [SerializeField] private RectTransform rightOffsetRectTransform;
        [SerializeField] private MeshFilter gameZoneBackgroundMeshFilter;

        private float _screenHeight;
        private float _screenWidth;
        private float _offsetWidthPercent;
        private float _horizontalPosOffsetPercent;

        private void CalculateWorldSize()
        {
            //https://www.youtube.com/watch?v=8iW2GbWlFWE
            //Measures word space by comparing view port and world space units
            var viewportPoint = mainCamera.WorldToViewportPoint(new Vector3(1f, 1f, 0f));
            _screenWidth = 1 / (viewportPoint.x - .5f);
            _screenHeight = 1 / (viewportPoint.y - .5f);
        }

        private void CalculateOffSets()
        {
            var screenWidth = Screen.width;
            var rightOffsetSize = rightOffsetRectTransform ? rightOffsetRectTransform.rect.width : 0f;
            var leftOffsetSize = leftOffsetRectTransform ? leftOffsetRectTransform.rect.width : 0f;
            var positionDifference = leftOffsetSize - rightOffsetSize;
            _horizontalPosOffsetPercent = positionDifference == 0 ? 0f : positionDifference / screenWidth / 2f;
            _offsetWidthPercent = (leftOffsetSize + rightOffsetSize) / screenWidth;
        }

        private void CalculateGameZone()
        {
            var gameZoneWidth = (1f - _offsetWidthPercent) * _screenWidth;
            var backgroundSize = gameZoneBackgroundMeshFilter.mesh.bounds.size;
            var backgroundTransform = gameZoneBackgroundMeshFilter.transform;
            backgroundTransform.localScale = new Vector3(gameZoneWidth / backgroundSize.x, 1f, _screenHeight / backgroundSize.z);
            var backgroundPos = backgroundTransform.localPosition;
            backgroundPos.x += _horizontalPosOffsetPercent * _screenWidth;
            backgroundTransform.localPosition = backgroundPos;
        }

        #region MonoBehaviour Methods

        private void Awake()
        {
            mainCamera ??= Camera.main;
        }

        private void Start()
        {
            CalculateWorldSize();
            CalculateOffSets();
            CalculateGameZone();
        }

        #endregion
    }
}