﻿using System;
namespace MathGame.kjanos89
{
    public class DivisionGame
    {
        int c;
        int points;
        Start startObject = new Start();
        public void Result()
        {
            Random numberGen = new Random();
            int a = numberGen.Next(1, 101);
            int b = numberGen.Next(1, 101);
            if(Math.Max(a,b)%Math.Min(a,b)!=0)
            {
                Result();
            }
            Console.Clear();
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine($"You currently have {GameData.Points} number of total points and this session {points} amount of points.");
            Console.WriteLine("Your choice was Division Game mode. The rules are simple: divine the bigger number with the smaller one");
            Console.WriteLine($"First number is {Math.Max(a, b)}");
            Console.WriteLine($"Second number is {Math.Min(a, b)}");
            Console.WriteLine("Pressing B will return you to the main menu.");
            Console.WriteLine("__________________________________________________________________");
            Validation(a, b);
        }

        public void Validation(int a, int b)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "b")
            {
                GameData.Games.Add($"{DateTime.Now}, Division Game Mode, Score earned in session: {points}");
                startObject.StartMenu();
            }
            else if (Int32.TryParse(input, out c))
            {
                if (c == Math.Max(a, b) / Math.Min(a, b))
                {
                    Console.WriteLine("Nice one! You just earned one point for yourself!");
                    Console.WriteLine("Starting again in 3 seconds!");
                    Thread.Sleep(3000);
                    GameData.Points++;
                    points++;
                    Result();
                }
                else
                {
                    Console.WriteLine("Not exactly, try again!");
                    Validation(a, b);
                }
            }
            else
            {
                Console.WriteLine("Not a number, try again!");
                Validation(a, b);
            }
        }
    }
}
