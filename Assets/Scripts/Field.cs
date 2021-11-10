using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class Field : MonoBehaviour
    {
        public GameObject cellPrefab;

        private const float distanceBetweenCellsX = 0.2f,
                            distanceBetweenCellsY = 0.2f;

        private const float cellWidth = 1f,
                            cellHeight = 1f;
        public void Create(int inputN, int inputM, int inputH, int inputK)
        {
            int halfSizeField = inputN / 2;
            //Все построение отталкивается от точки (0; 0)
            Vector2 centralPoint = Vector2.zero;
            Vector2 leftPoint = new Vector2(-halfSizeField * cellWidth, 0);
            Vector2 UpperLeftPoint = centralPoint + leftPoint + new Vector2(0, +halfSizeField * cellHeight);

            Vector2 cellPosition = UpperLeftPoint;

            int numberCellsX = inputN,
                numberCellsY = inputN;

            for (int cell_x = 0; cell_x < numberCellsX; cell_x++)
            {
                for (int cell_y = 0; cell_y < numberCellsY; cell_y++)
                {
                    //Создаем кл в Field в позиции cellPosition
                    GameObject newCell = Instantiate<GameObject>(cellPrefab, cellPosition, new Quaternion(), this.transform);

                    //Инициализируем координаты кл
                    newCell.GetComponent<Cell>().InitializeCoordinates(new Coordinates(cell_x, cell_y));

                    //Сдвигаем позицию кл вправо на (ширина кл + растояние между кл по оси X)
                    cellPosition.x += cellWidth + distanceBetweenCellsX;
                }

                cellPosition.x = leftPoint.x;
                //Сдвигаем позицию кл вниз на (высоту кл + растояние между кл по оси Y)
                cellPosition.y -= cellHeight + distanceBetweenCellsY;
            }
        }

        public void Clear()
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }
            for (int idxChild = 0; idxChild < children.Count; idxChild++)
            {
                Destroy(children[idxChild].gameObject);
            }
        }

        private void DistributeAwards()
        {

        }
    }
}