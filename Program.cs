using System.ComponentModel;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //field[height/Y][width/X]
            var fieldHeight = 8;
            var fieldWidth = 8;

            //Snake location
            var snakeX = 0;
            var snakeY = 0;

            //Food location
            var foodX = 0;
            var foodY = 0;

            //Direction: Add to snake location each frame
            var snakeXDir = 1;
            var snakeYDir = 0;

            //Array values
            var empty = 0;
            var food = 1;
            var snake = 2;

            var rand = new Random();

            //Create empty field
            var field = new int[fieldHeight][];
            for(int i = 0; i < field.Length; i++)
            {
                field[i] = new int[fieldWidth];
            }

            //Add first piece of food
            foodX = (int)rand.NextInt64(1, fieldWidth);
            foodY = (int)rand.NextInt64(1, fieldHeight);
            field[foodY][foodX] = food;

            //Add snake to field
            field[snakeY][snakeX] = snake;

            //Create snake tail location
            var snakeLength = 1;
            var snakeLocation = new Queue<(int, int)>();
            snakeLocation.Enqueue((snakeX, snakeY));

            var endGame = false;
            while (!endGame)
            {
                //print field to console
                //if tail is too long
                    //pop off end of tail and clear that field location
                //decide which direction the snake should move
                //move the snake forward (add direction to location)
                //if the snake is on the food
                    //add to the snake length
                    //create new food
                //if the snake is on itself
                    //end the game

                //print field to console
                for(int i = 0; i < field.Length; i++)
                {
                    for(int j = 0; j < field[i].Length; j++)
                    {
                        if(field[i][j] != empty)
                        {
                            Console.Write(field[i][j]);
                        }
                        else
                        {
                            Console.Write('.');
                        }
                        
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                //if tail is too long
                if(snakeLocation.Count > snakeLength)
                {
                    //pop off end of tail and clear that field location
                    var endOfTail = snakeLocation.Dequeue();
                    field[endOfTail.Item2][endOfTail.Item1] = empty;
                }

                //decide which direction the snake should move
                //It will be dumb and head straight for the food
                snakeXDir = 0;
                snakeYDir = 0;
                if(snakeX < foodX)
                {
                    snakeXDir = 1;
                }
                else if(snakeX > foodX)
                {
                    snakeXDir = -1;
                }
                else
                {
                    if (snakeY < foodY)
                    {
                        snakeYDir = 1;
                    }
                    else if (snakeY > foodY)
                    {
                        snakeYDir = -1;
                    }
                }

                //move the snake forward (add direction to location)
                snakeX += snakeXDir;
                snakeY += snakeYDir;
                snakeLocation.Enqueue((snakeX, snakeY));

                var newSnakePlace = field[snakeY][snakeX];

                //if the snake is on the food
                if (newSnakePlace == food)
                {
                    //add to the snake length
                    snakeLength++;
                    //create new food
                    //This will be dumb and just try random locations until it find
                    //one that's empty
                    while (field[foodY][foodX] != empty)
                    {
                        foodX = (int)rand.NextInt64(fieldWidth);
                        foodY = (int)rand.NextInt64(fieldHeight);
                    }
                    field[foodY][foodX] = food;

                    field[snakeY][snakeX] = snake;
                }
                //if the snake hit itself
                else if (newSnakePlace == snake)
                {
                    //end the game
                    endGame = true;
                } 
                else if (newSnakePlace == empty)
                {
                    field[snakeY][snakeX] = snake;
                }

                Thread.Sleep(500);
            }
        }
    }
}