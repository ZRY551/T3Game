using System;


namespace T3Game
{

    public class Game
    {

        public const int chessboard_line = 3;
        public static readonly int[,] chessboard_default = new int[3, 3];
        public int[,] chessboard = new int[3, 3];

        public enum playerEnum
        {
            System,
            White,
            Black,
        };

        public Dictionary<int, string> playerIndex = new Dictionary<int, string>(){
            { 0, "系统" },
            { 1, "白方" },
            { 2, "黑方" },
        };

        public enum winEnum
        {
            System,
            White,
            Black,
            Draw,
        };

        public Dictionary<int, string> winIndex = new Dictionary<int, string>(){
            { 0, "系统" },
            { 1, "白方" },
            { 2, "黑方" },
            { 3, "平局" },
        };

        public enum chessEnum
        {
            System,
            White,
            Black,
            None,
        };
        public Dictionary<int, string> chessIndex = new Dictionary<int, string>(){
            { 0, "系统" },
            { 1, "白方" },
            { 2, "黑方" },
            { 3, "空气" },
        };



        public Game()
        {

        }

        public Game(string[] args)
        {

        }

        public void Start()
        {
            this.ShowMainScreen();

        }

        public void Exit()
        {
            var title = "井字棋小游戏 - 退出";
            Console.Title = title;
            void PrintExitInfo()
            {
                Console.Clear();
                Console.WriteLine("确认退出吗？未保存的进度都将丢失！");
                Console.WriteLine("");
                Console.WriteLine("[A] 确认");
                Console.WriteLine("[B] 取消");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            void RunExit()
            {
                Console.Clear();
                Console.WriteLine(">>> Bye~Bye~");
                this.StopApp();
            }
            PrintExitInfo();
            while (true)
            {
                Console.Title = title;
                var key = Console.ReadKey();


                if (key.Key == ConsoleKey.A)
                {
                    RunExit();
                    //continue;
                }

                if (key.Key == ConsoleKey.B)
                {
                    return;
                }


                if (key.Key == ConsoleKey.Escape)
                {
                    RunExit();
                }
                PrintExitInfo();
                Console.WriteLine("");
                continue;
            }
        }

        public void StopApp()
        {
            Environment.Exit(0);
        }

        public void ShowMainScreen()
        {
            var title = "井字棋小游戏 - 主菜单";
            Console.Title = title;
            void PrintMainInfo()
            {
                Console.Clear();
                Console.WriteLine("欢迎游玩井字棋小游戏！");
                Console.WriteLine("");
                Console.WriteLine("[A] 本地单人游戏");
                Console.WriteLine("[B] 本地双人游戏");
                Console.WriteLine("[C] 联网双人游戏");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            PrintMainInfo();
            while (true)
            {
                Console.Title = title;
                var key = Console.ReadKey();


                if (key.Key == ConsoleKey.A)
                {
                    PrintMainInfo();
                    Console.WriteLine(">>> 暂不支持该类型的游戏");
                    // DrawChessBoard();
                    // break;
                    continue;
                }


                if (key.Key == ConsoleKey.Escape)
                {
                    this.Exit();
                }
                PrintMainInfo();
                Console.WriteLine("");
                continue;
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ingame_playNow = 0;

        public List<CheckerboardOperation> ingame_chessHistory = new List<CheckerboardOperation>();

        public static string GetChessByNumber(int n){
            if( n == 0) return "?";
            if( n == 1) return "■";
            if( n == 2) return "■";
            if( n == 3) return " ";
            return "";
        }

        public void DrawChessBoard()
        {

            Console.WriteLine("现在轮到 " + playerIndex[this.ingame_playNow] + " 下棋");
            Console.WriteLine("");
            Console.WriteLine("");
            for (int i = 0; i < chessboard_line; i++)
            {
                for (int j = 0; j < chessboard_line; j++)
                {
                    Console.Write(GetChessByNumber(j) + " ");

                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");





        }


        public void AddChessHistory(int who, int x, int y, int chess, int data)
        {
            var obj = new CheckerboardOperation();
            obj.who = who;
            obj.x = x;
            obj.y = y;
            obj.chess = chess;
            obj.data = data;
            ingame_chessHistory.Add(obj);
        }








    }





}