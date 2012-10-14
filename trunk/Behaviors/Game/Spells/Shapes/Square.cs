using System;
using System.Collections.Generic;
using BiM.Behaviors.Game.World;
using BiM.Protocol.Enums;

namespace BiM.Behaviors.Game.Spells.Shapes
{
    public class Square : IShape
    {
        public Square(byte minRadius, byte radius)
        {
            MinRadius = minRadius;
            Radius = radius;
        }

        public bool DiagonalFree
        {
            get;
            set;
        }

        #region IShape Members

        public uint Surface
        {
            get
            {
                return ( (uint)Radius * 2 + 1 ) * ( (uint)Radius * 2 + 1 );
            }
        }

        public byte MinRadius
        {
            get;
            set;
        }

        public DirectionsEnum Direction
        {
            get;
            set;
        }

        public byte Radius
        {
            get;
            set;
        }

        public Cell[] GetCells(Cell centerCell, Map map)
        {
            var result = new List<Cell>();

            if (Radius == 0)
            {
                if (MinRadius == 0 && !DiagonalFree)
                    result.Add(centerCell);

                return result.ToArray();
            }

            int x = (int)( centerCell.X - Radius );
            int y;
            while (x <= centerCell.X + Radius)
            {
                y = (int) (centerCell.Y - Radius);
                while (y <= centerCell.Y - Radius)
                {
                    if (MinRadius == 0 || Math.Abs(centerCell.X - x) + Math.Abs(centerCell.Y - y) >= MinRadius)
                        if (!DiagonalFree || Math.Abs(centerCell.X - x) != Math.Abs(centerCell.Y - y))
                             AddCellIfValid(x, y, map, result);

                    y++;
                }

                x++;
            }

            return result.ToArray();
        }

        private static void AddCellIfValid(int x, int y, Map map, IList<Cell> container)
        {
            if (!Cell.IsInMap(x, y))
                return;

            container.Add(map.Cells[x, y]);
        }
        #endregion
    }
}