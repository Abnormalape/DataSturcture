﻿using System.Xml.Linq;

class Programm
{
    static void PrintLocation(Maze maze, int xPos, int yPos, int delay)
    {
        Thread.Sleep(delay);
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < maze.GetSize(); y++)
        {
            for (int x = 0; x < maze.GetSize(); x++)
            {
                if (x == xPos && y == yPos)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("P ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (maze[x, y] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{maze[x, y]} ");

                // 색상 초기화.
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();


        }
    }
    static void Main(string[] args)
    {
        Maze maze = new Maze();
        //maze.Print();

        // 시작 지점 저장 용 변수 선언.
        Location2D startLocation = new Location2D();

        // 시작 지점 검색.
        for (int y = 0; y < maze.GetSize(); ++y)
        {
            for (int x = 0; x < maze.GetSize(); ++x)
            {
                // 시작 지점 검색 후 저장.
                if (maze[x, y] == 'e')
                {
                    startLocation = new Location2D(x, y);
                    break;
                }
            }
        }

        // 미로 출력.
        maze.Print();

        MazeStack<Location2D> stack = new MazeStack<Location2D>();
        stack.Push(startLocation);

        int count = 0;
        while (stack.IsEmpty == false)
        {

            if (stack.Pop(out Location2D currentLocation))
            {
                // 현재 위치 탐색.
                //Console.Write($"({currentLocation.X},{currentLocation.Y}) ");
                PrintLocation(maze, currentLocation.X, currentLocation.Y, 50);

                // 가로 10칸 출력한 후 엔터 코드 입력.
                //count++;
                //if (count % 10 == 0)
                //{
                //    Console.WriteLine();
                //}

                //이동한 위치가 탈출지점인지 비교(미로탈출 성공)
                if (maze[currentLocation.X, currentLocation.Y] == 'x')
                {
                    maze[currentLocation.X, currentLocation.Y] = 'p';
                    Console.WriteLine("\n\n미로 탐색 성공");

                    maze.Print();
                    Console.ReadKey();

                    return;
                }
                //이동한 위치가 출구가 아니라면 방문했다고 표기
                maze[currentLocation.X, currentLocation.Y] = '.';
                //상하좌우 위치중 이동 가능한 위치를 스택에 삽입
                if (maze.IsValidLocation(currentLocation.X, currentLocation.Y - 1))
                {
                    stack.Push(new Location2D(currentLocation.X, currentLocation.Y - 1));
                }
                if (maze.IsValidLocation(currentLocation.X, currentLocation.Y + 1))
                {
                    stack.Push(new Location2D(currentLocation.X, currentLocation.Y + 1));
                }
                if (maze.IsValidLocation(currentLocation.X - 1, currentLocation.Y))
                {
                    stack.Push(new Location2D(currentLocation.X - 1, currentLocation.Y));
                }
                if (maze.IsValidLocation(currentLocation.X + 1, currentLocation.Y))
                {
                    stack.Push(new Location2D(currentLocation.X + 1, currentLocation.Y));
                }
            }

        }


        maze.Print();
        Console.WriteLine("\n미로 탐색 실패.");

        Console.ReadKey();
    }
}
