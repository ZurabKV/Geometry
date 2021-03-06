﻿using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Entities.ComplexObjects;

namespace Geometry.Entities.PrimitiveObjects
{
    class LightRay : PrimitiveObject
    {
        private Pixel startPoint;
        private Pixel endPoint;
        public double length;

        public LightRay(Pixel source, Pixel goal, char shape, ConsoleColor color) : base(shape, color)
        {
            startPoint = source;
            endPoint = goal;
            length = GenerateBody();
        }

        public override void Draw()
        {
            Body.Pixels.ToList().ForEach(p => p.Draw());
        }
        
        private bool CheckIfIntersectedAnyVisiblePixel(Pixel currentPixel)
        {
            bool result = false;
            if (GameMemory.visibleComplexObjectsList.Count==0)
            {
                return result;
            }
            foreach (ComplexObject<PrimitiveObject> complexObject in GameMemory.visibleComplexObjectsList)
            {
                foreach (PrimitiveObject MultipixelObj in complexObject.Body.Parts)
                {
                    foreach (Pixel pixel in MultipixelObj.Body.Pixels)
                    {
                        if (pixel.Xgrid == currentPixel.Xgrid && pixel.Ygrid == currentPixel.Ygrid)
                        {
                            result = true;
                            pixel.isLit = result;
                        }
                    }
                }
            }
            
            return result;
        }

        private double GenerateBody()
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
            // currentCell.Draw(); //for debugging
            //endPoint.Draw(); //for debugging

            while ((currentCell.x == endPoint.x && currentCell.y == endPoint.y) == false)
            {
                freeMovesLeft++;
                moderatedMovesLeft += restrictedMovesMaxFloor;
                if (FreeMarching(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft))
                {
                    return currentCell.DistanceToAnotherPixel(startPoint);
                }
                if (RestrictedMarching(ref currentCell, ref moderatedMovesLeft, FloatingPointDelta))
                {
                    return currentCell.DistanceToAnotherPixel(startPoint);
                }
            }

            endPoint.isLit = true;
            return currentCell.DistanceToAnotherPixel(startPoint);
        }

        private bool RestrictedMarching(ref Pixel currentCell, ref double moderatedMovesLeft, double FloatingPointDelta)
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

                if (CheckIfIntersectedAnyVisiblePixel(currentCell))
                {
                    return true;
                }
                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
            return false;
        }

        private bool FreeMarching(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft)
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

                if (CheckIfIntersectedAnyVisiblePixel(currentCell))
                {
                    return true;
                }

                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
            return false;
        }
    }
}
