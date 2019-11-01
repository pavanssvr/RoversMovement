using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class RoverMovementService : IRoverMovementService
    {
       static readonly Dictionary<char, int> directionsClockWise = new Dictionary<char, int>(){
                {'N',0 },{'E',1 },{'S',2 },{'W',3 }
            };
        static readonly Dictionary<char, int> directionsAntiClockWise = new Dictionary<char, int>(){
                {'N',0 },{'W',1 },{'S',2 },{'E',3 }
            };

        public string RoverMovement(RoverPosition roverPosition)
        {
            string roversPosition = roverPosition.Position;
            string movementDirections = roverPosition.MovementSignals;

            int xMaxValue = (int)Char.GetNumericValue(roverPosition.Plateau[0]);
            int yMaxValue = (int)Char.GetNumericValue(roverPosition.Plateau[1]);

            int xAxisPosition = (int)Char.GetNumericValue(roversPosition[0]);
            int yAxisPosition = (int)Char.GetNumericValue(roversPosition[1]);
            char currentDirection = roversPosition[2];

            foreach (char movement in movementDirections)
            {
                switch (movement)
                {
                    case 'L'://Left
                        currentDirection = GetDirection(currentDirection, false);
                        break;
                    case 'R': //Right
                        currentDirection = GetDirection(currentDirection, true);
                        break;
                    case 'M': //Movement
                        switch (currentDirection)
                        {
                            case 'W'://West
                                xAxisPosition--;
                                break;
                            case 'E': //East
                                xAxisPosition++;
                                break;
                            case 'N': //North
                                yAxisPosition++;
                                break;
                            case 'S': //South
                                yAxisPosition++;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            return $"{xAxisPosition.ToString()} {yAxisPosition.ToString()} {currentDirection}";
        }

        private char GetDirection(char currentDirection, bool clockWise)
        {
            char roverDirection;
            int currentPosition;

            if (!clockWise)
            {
                currentPosition = directionsAntiClockWise[currentDirection];
                int position = (currentPosition + 1) % 4;
                roverDirection = directionsAntiClockWise.FirstOrDefault(d => d.Value == position).Key;
            }
            else
            {
                currentPosition = directionsClockWise[currentDirection];
                int position = (currentPosition + 1) % 4;
                roverDirection = directionsClockWise.FirstOrDefault(d => d.Value == position).Key;
            }
            return roverDirection;
        }
    }
}
