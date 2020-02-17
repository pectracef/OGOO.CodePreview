using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        public Guid roverId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Rover's point X on coordinate system
        /// </summary>
        public byte pointX { get; set; } = 0;
        /// <summary>
        /// Rover's point Y on coordinate system
        /// </summary>
        public byte pointY { get; set; } = 0;
        /// <summary>
        /// Rover's direction on coordinate system
        /// </summary>
        public Direction facing { get; set; } = 0;

        /// <summary>
        /// Create a new instance rover without parameters
        /// </summary>
        public Rover()
        {

        }

        /// <summary>
        /// Create a new instance rover with parameters.
        /// </summary>
        /// <param name="pointX"></param>
        /// <param name="pointY"></param>
        /// <param name="facing"></param>
        public Rover(byte pointX, byte pointY, Direction facing)
        {
            this.pointX = pointX;
            this.pointY = pointY;
            this.facing = facing;
        }

        /// <summary>
        /// Moving rover on direction
        /// </summary>
        private void Move()
        {
            switch (facing)
            {
                case Direction.N:
                    this.pointY++;
                    break;
                case Direction.E:
                    this.pointX++;
                    break;
                case Direction.S:
                    this.pointY--;
                    break;
                case Direction.W:
                    this.pointX--;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Change rotation rover
        /// </summary>
        /// <param name="rotation"></param>
        private void ChangeRotation(char rotation)
        {
            switch (rotation)
            {
                case 'L':
                    if(this.facing == Direction.N)
                    {
                        this.facing += 3;
                    }
                    else
                    {
                        this.facing--;
                    }
                    break;
                case 'R':
                    if (this.facing == Direction.W)
                    {
                        this.facing -= 3;
                    }
                    else
                    {
                        this.facing++;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Applies commands transmitted to the rover
        /// </summary>
        /// <param name="command">Command string example: MMLMRRMLRMM (M is move, L is left direction, R is right direction)</param>
        public void RunCommand(string command)
        {
            char[] commandLines = command.ToCharArray();
            foreach (char line in commandLines)
            {
                if(line == 'M')
                {
                    Move();
                }
                else
                {
                    ChangeRotation(line);
                }
            }
        }
    }

    /// <summary>
    /// Direction of the rover
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Direction North
        /// </summary>
        N,
        /// <summary>
        /// Direction East
        /// </summary>
        E,
        /// <summary>
        /// Direction South
        /// </summary>
        S,
        /// <summary>
        /// Direction West
        /// </summary>
        W
    }
}
