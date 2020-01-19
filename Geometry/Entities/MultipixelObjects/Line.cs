using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Geometry.Entities.BodyParts;

namespace Geometry.Entities.MultipixelObjects
{
     class Line : MultipixelObject
    {
        private Pixel startPoint;
        private Pixel endPoint;

        public Line(Pixel startPoint, Pixel endPoint, char shape, ConsoleColor color) : base(shape, color)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            GenerateBody();
        }

        public override void Draw()
        {
            Body.Pixels.ToList().ForEach(p => p.Draw());
        }
        
        private void GenerateBody()
        {
            double distX = endPoint.x - startPoint.x;
            double distY = endPoint.y - startPoint.y;

            double directionCoef = Math.Abs(distX / distY);

            if (distX == 0 || distY == 0)
            {
                directionCoef=1;
            }

            double directionCoef1Plus = directionCoef > 1 ? directionCoef : 1 / directionCoef;
            double restrictedMovesMaxFloor = Math.Floor(directionCoef1Plus);
            double FloatingPointDelta = directionCoef1Plus - Math.Floor(directionCoef1Plus);
            double moderatedMovesLeft = 0;
            int freeMovesLeft = 0;

            Pixel currentCell = startPoint;
            //currentCell.Draw(); //for debugging
            //endPoint.Draw(); //for debugging

            while ((currentCell.x == endPoint.x && currentCell.y == endPoint.y) == false)
            {
                freeMovesLeft++;
                moderatedMovesLeft += restrictedMovesMaxFloor;
                FreeMarching(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft);
                RestrictedMarching(ref currentCell, ref moderatedMovesLeft, FloatingPointDelta);
            }

            endPoint.IsLit = true;
        }

        private void RestrictedMarching(ref Pixel currentCell, ref double moderatedMovesLeft, double FloatingPointDelta)
        {
            moderatedMovesLeft += FloatingPointDelta;

            while (moderatedMovesLeft >= 1)
            {
                Pixel nearestCellSoFar = currentCell;

                List<Pixel> surroundingCells = currentCell.GetSurroundingCells();

                for (int i = 0; i < surroundingCells.Count; i++)
                {
                    Pixel cellOnReview = surroundingCells[i];

                    var nearestDistanceSoFar = nearestCellSoFar.DistanceToAnotherPixel(endPoint);
                    var distanceOnReviev = cellOnReview.DistanceToAnotherPixel(endPoint);

                    if (distanceOnReviev < nearestDistanceSoFar)
                    {
                        if (cellOnReview.IsNotDiagonalToAnotherNearestPixel(currentCell))
                        {
                            nearestCellSoFar = cellOnReview;
                        }
                    }
                }

                currentCell = nearestCellSoFar;
                moderatedMovesLeft--;
                //currentCell.Draw(); //for debugging
                
                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
        }

        private void FreeMarching(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft)
        {
            while (freeMovesLeft >= 1)
            {
                List<Pixel> surroundingCells = currentCell.GetSurroundingCells();

                foreach (Pixel cell in surroundingCells)
                {
                    var chosenDist = currentCell.DistanceToAnotherPixel(endPoint);
                    var dist = cell.DistanceToAnotherPixel(endPoint);

                    if (dist < chosenDist)
                    {
                        currentCell = cell;
                    }
                }

                freeMovesLeft--;
                moderatedMovesLeft--; 

                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
        }
    }
}