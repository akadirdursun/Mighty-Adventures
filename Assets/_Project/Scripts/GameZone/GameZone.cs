using UnityEngine;

namespace MightyAdventures.GameZone
{
    public class GameZone : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameZoneData gameZoneData;
        [SerializeField] private RectTransform leftOffsetRectTransform;
        [SerializeField] private RectTransform rightOffsetRectTransform;
        [SerializeField] private MeshFilter gameZoneBackgroundMeshFilter;
        [SerializeField] private float backgroundDepth = -5;
        [SerializeField] private float spawnDepth;
        [SerializeField] private float verticalSpawnPosOffset;
        [SerializeField] private float spawnAreaHeight;
        [SerializeField, Range(0f, 1f)] private float spawnAreaWidthOffset;
        private float _backgroundHeight;
        private float _backgroundWidth;
        private float _spawnAreaWidth;
        private float _spawnAreaHeight;
        private float _offsetWidthPercent;
        private float _horizontalPosOffsetPercent;

        private void CalculateWorldSize()
        {
            //https://www.youtube.com/watch?v=8iW2GbWlFWE
            //Measures word space by comparing view port and world space units
            var viewportPoint = mainCamera.WorldToViewportPoint(new Vector3(1f, 1f, backgroundDepth));
            _backgroundWidth = 1 / (viewportPoint.x - .5f);
            _backgroundHeight = 1 / (viewportPoint.y - .5f);
            var spawnAreaViewport = mainCamera.WorldToViewportPoint(new Vector3(1f, 1f, spawnDepth));
            _spawnAreaWidth = 1 / (spawnAreaViewport.x - 0.5f);
            _spawnAreaHeight = 1 / (spawnAreaViewport.y - .5f);
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
            var gameZoneWidth = (1f - _offsetWidthPercent) * _backgroundWidth;
            var backgroundSize = gameZoneBackgroundMeshFilter.mesh.bounds.size;
            var backgroundTransform = gameZoneBackgroundMeshFilter.transform;
            backgroundTransform.localScale = new Vector3(gameZoneWidth / backgroundSize.x, 1f, _backgroundHeight / backgroundSize.z);
            var backgroundPos = backgroundTransform.localPosition;
            backgroundPos.x += _horizontalPosOffsetPercent * _backgroundWidth;
            backgroundPos.z = backgroundDepth;
            backgroundTransform.localPosition = backgroundPos;

            var spawnAreaVerticalCenter = -_spawnAreaHeight * .5f + verticalSpawnPosOffset - spawnAreaHeight * .5f;
            var spawnAreaHorizontalCenter = backgroundPos.x;
            var spawnAreaWidth = (1f - (_offsetWidthPercent + spawnAreaWidthOffset)) * _spawnAreaWidth;
            gameZoneData.GameZoneBounds = new Bounds(new Vector3(spawnAreaHorizontalCenter, spawnAreaVerticalCenter, spawnDepth),
                new Vector3(spawnAreaWidth, spawnAreaHeight, _spawnAreaWidth));
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