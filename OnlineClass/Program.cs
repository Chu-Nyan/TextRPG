
internal class Program
{
    static void Main(string[] args)
    {
        //Gesangi gesangi = new Gesangi();
        //Console.ReadLine();
        //Console.Clear();

        //Updown updown = new Updown();
        //Console.ReadLine();
        //Console.Clear();

        //TicTacToe ticTacToe = new TicTacToe();
        //Console.ReadLine();
        //Console.Clear();

        //BlackJack blackJack = new BlackJack();
        //Console.ReadLine();
        //Console.Clear();

        //SneakGame sneakGame = new SneakGame();


    }
}

class Gesangi
{
    public Gesangi()
    {
        Console.WriteLine("이름을 입력해주세요.");
        string name = Console.ReadLine();
        Console.WriteLine("나이를 입력해주세요.");
        string age = Console.ReadLine();


        string message = "나의 이름은 " + name + "입니다. 나이는 " + age + "살 입니다.";
        Console.WriteLine(message);


        Console.WriteLine("첫 번째 숫자 입력");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("두 번째 숫자 입력");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} + {1} = " + (num1 + num2), num1, num2);
        Console.WriteLine("{0} - {1} = " + (num1 - num2), num1, num2);
        Console.WriteLine("{0} * {1} = " + (num1 * num2), num1, num2);
        Console.WriteLine("{0} / {1} = " + (num1 / num2), num1, num2);

        Console.WriteLine("섭씨 입력");
        float subC = float.Parse(Console.ReadLine());

        float fireC = subC * 1.8f + 32;

        Console.WriteLine($"{subC}°C를 화씨를 바꾸면 {fireC}°F입니다");

        Console.WriteLine("이름 키(cm) 몸무게(kg)'를 띄어쓰기하여 입력해주세요.");
        string namekeyWeight = Console.ReadLine();
        string[] userInfoArr = namekeyWeight.Split();

        string name1 = userInfoArr[0];
        float key = float.Parse(userInfoArr[1]) / 100;
        float weight = float.Parse(userInfoArr[2]);

        float BMI = weight / (key * key);

        Console.Write(name1 + "님의 BMI의 지수는 ");
        Console.Write(BMI.ToString("N2") + "점 입니다.");
    }
}

class TicTacToe
{
    public TicTacToe()
    {
        char[,] gameBorad = new char[3, 3]
           {
                { '□','□','□'},
                { '□','□','□'},
                { '□','□','□'}
           };

        int choiceX;
        int choiceY;
        bool ischoiceFail = false;
        bool isGameing = true;
        char winTeam = ' ';

        while (isGameing == true)
        {
            ScreenRender();

            if (ischoiceFail == false)
            {
                Console.WriteLine("몇 번째 칸을 선택 하시겠습니까?");
            }
            else
            {
                Console.WriteLine("다시 선택해주세요.");
                ischoiceFail = false;
            }
            Console.WriteLine("가로");
            choiceX = int.Parse(Console.ReadLine());
            Console.WriteLine("세로");
            choiceY = int.Parse(Console.ReadLine());

            if (gameBorad[3 - choiceY, choiceX - 1] == '□')
            {
                gameBorad[3 - choiceY, choiceX - 1] = '●';
                WinTrigger();
                randomChoice();
                WinTrigger();
                Console.Clear();
            }
            else
            {
                ischoiceFail = true;
                Console.Clear();
            }

        }

        ScreenRender();
        Console.WriteLine($"{winTeam}가 승리하였습니다.");

        void ScreenRender()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (x == 0)
                    {
                        Console.Write("▲");
                    }
                    Console.Write(gameBorad[y, x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("▣▶▶▶");
            Console.WriteLine("--------");
        }

        void randomChoice()
        {
            while (true)
            {
                int randomX = new Random().Next(0, 3);
                int randomY = new Random().Next(0, 3);

                if (gameBorad[randomY, randomX] == '□')
                {
                    gameBorad[randomY, randomX] = '★';
                    break;
                }
            }
        }

        void WinTrigger()
        {
            char case1 = ' ';
            char case2;

            for (int y = 0; y < 3; y++) // 가로
            {
                for (int x = 0; x < 3; x++)
                {
                    if (gameBorad[y, x] == '□')
                    {
                        break;
                    }
                    if (x == 0)
                    {
                        case1 = gameBorad[y, x];
                    }
                    else if (gameBorad[y, x] != case1)
                    {
                        break;
                    }
                    else if (x == 2)
                    {
                        winTeam = gameBorad[y, x];
                        isGameing = false;
                    }
                }
            }

            for (int x = 0; x < 3; x++) // 세로
            {
                for (int y = 0; y < 3; y++)
                {
                    if (gameBorad[y, x] == '□')
                    {
                        break;
                    }
                    if (y == 0)
                    {
                        case1 = gameBorad[y, x];
                    }
                    else if (gameBorad[y, x] != case1)
                    {
                        break;
                    }
                    else if (y == 2)
                    {
                        winTeam = gameBorad[y, x];
                        isGameing = false;
                    }
                }
            }

            for (int num = 0; num < 3; num++) // '/' 빙고
            {
                if (gameBorad[num, num] == '□')
                {
                    break;
                }
                if (num == 0)
                {
                    case1 = gameBorad[num, num];
                }
                else if (gameBorad[num, num] != case1)
                {
                    break;
                }
                else if (num == 2)
                {
                    winTeam = gameBorad[num, num];
                    isGameing = false;
                }
            }

            for (int num = 0; num < 3; num++) // '\' 빙고
            {
                if (gameBorad[num, 2 - num] == '□')
                {
                    break;
                }
                if (num == 0)
                {
                    case1 = gameBorad[num, 2 - num];
                }
                else if (gameBorad[num, 2 - num] != case1)
                {
                    break;
                }
                else if (num == 2)
                {
                    winTeam = gameBorad[num, 2 - num];
                    isGameing = false;
                }
            }

        }
    }
}

class Updown
{
    public Updown()
    {
        int randomNum = new Random().Next(0, 101);
        int choiceNum = 101;

        int minNum = 0;
        int maxNum = 100;
        while (randomNum != choiceNum)
        {
            Console.WriteLine($"{minNum}에서 {maxNum}까지 숫자를 선택해주세요.");
            choiceNum = int.Parse(Console.ReadLine());
            if (randomNum > choiceNum)
            {
                minNum = choiceNum;
                Console.WriteLine("더 큰 숫자를 선택해주세요.");
            }
            else if (randomNum < choiceNum)
            {
                maxNum = choiceNum;
                Console.WriteLine("더 작은 숫자를 선택해주세요.");
            }
            else if (randomNum == choiceNum)
            {
                Console.WriteLine("정답!!");
            }
        }
    }
}

class BlackJack
{
    public delegate void PrintDelegate();
    PrintDelegate PrintCardsSum;

    int DealCards = 0;
    int playerCardSum = 0;
    int dealerCardSum = 0;
    static public bool isGameStop = false;
    bool isOverCardsSum = false;

    int[] Cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };
    Random random = new Random();

    public BlackJack()
    {

        playerCardSum += Cards[random.Next(0, Cards.Length)];
        dealerCardSum += Cards[random.Next(0, Cards.Length)];
        DealCards++;
        PrintCardsSum = () =>
        {
            Console.WriteLine($"당신의 카드 합 : {playerCardSum}");
            Console.WriteLine($"딜러의 카드 합 : {dealerCardSum}");
        };

        while (true)
        {
            Console.Clear();
            DealPhase();
            ActionPhase();
            if (CardOpen() == true)
            {
                break;
            }

        }
    }

    public void DealPhase()
    {
        playerCardSum += Cards[random.Next(0, Cards.Length)];
        if (dealerCardSum <= 17)
        {
            dealerCardSum += Cards[random.Next(0, Cards.Length)];
        }
        DealCards++;
        Console.WriteLine("카드를 배분하였습니다");
        if (playerCardSum > 21)
        {
            isOverCardsSum = true;
        }
    }

    public void ActionPhase()
    {
        Console.WriteLine($"배분된 카드 : {DealCards}");
        Console.WriteLine($"나의 카드 합 : {playerCardSum}");
        if (isOverCardsSum == true)
        {
            Console.WriteLine();
            Console.WriteLine("카드합이 21을 넘었습니다.");
            Console.WriteLine("당신이 패배하였습니다.");
            return;
        }

        Console.WriteLine("어떻게 하시겠습니까?");
        Console.WriteLine("1. 계속한다 2. 멈춘다");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                isGameStop = false;
                break;
            case ConsoleKey.D2:
                isGameStop = true;
                break;
            default:
                Console.WriteLine("다시 선택해주세요");
                break;
        }
    }


    public bool CardOpen()
    {
        if (isOverCardsSum == true)
        {
            return true;
        }
        if (isGameStop == false)
        {
            return false;
        }
        if (playerCardSum > dealerCardSum)
        {
            Console.WriteLine();
            Console.WriteLine("당신이 이겼습니다.");
            PrintCardsSum();
        }
        else if (playerCardSum < dealerCardSum)
        {
            Console.WriteLine();
            Console.WriteLine("딜러가 이겼습니다.");
            PrintCardsSum();
        }
        else if (playerCardSum == dealerCardSum)
        {
            Console.WriteLine();
            Console.WriteLine("무승부");
            PrintCardsSum();
        }

        return true;
    }

}

class SneakGame
{
    bool IsGameOver = false;
    char[,] gameBoard;
    int gameBoardSize = 21;
    int playerPosX;
    int playerPosY;

    List<List<int>> tails = new List<List<int>>();
    int eatFood = 0;
    bool isAliveFood = false;
    bool isYesInput = false;

    public ConsoleKey lastKeyInPut;
    ConsoleKeyInfo inputKey = new ConsoleKeyInfo();


    public SneakGame()
    {
        gameBoard = new char[gameBoardSize, gameBoardSize];
        int defultPos = gameBoardSize / 2;
        gameBoard[defultPos, defultPos] = '◆';
        playerPosX = playerPosY = defultPos;
        tails.Add(new List<int>());
        tails[0].Add(0);
        tails[0].Add(0);

        // 실행 부분 //

        MakeGameBoard();
        PlayerSetting();
        MakeFood();
        RenderScreen();

        while (true)
        {
            ClearGameBoard();
            InputKey();
            InputSneakTails();
            MakeFood();
            RenderScreen();
            if (CheckGameOver() == true)
            {
                Console.WriteLine("Game Over");
                break;
            }
            Thread.Sleep(100);

        }
    }


    public void MakeGameBoard() // 게임 보드의 초기 세팅
    {
        for (int y = 0; y < gameBoardSize; y++)
        {
            for (int x = 0; x < gameBoardSize; x++)
            {
                if (x == 0 || x == gameBoardSize - 1 || y == 0 || y == gameBoardSize - 1)
                {
                    gameBoard[y, x] = '　';
                    continue;
                }
                gameBoard[y, x] = '□';
            }
        }
    }


    public void ClearGameBoard() // 게임 보드를 초기화
    {

        for (int y = 0; y < gameBoardSize; y++)
        {
            for (int x = 0; x < gameBoardSize; x++)
            {
                if (x == 0 || x == gameBoardSize - 1 || y == 0 || y == gameBoardSize - 1)
                {
                    gameBoard[y, x] = '　';
                    continue;
                }

                if (gameBoard[y, x] == '■' || gameBoard[y, x] == '◆')
                {
                    gameBoard[y, x] = '□';
                }
            }
        }
    }


    public void RenderScreen() // 게임 보드를 출력
    {
        Console.Clear();
        for (int y = gameBoardSize - 1; y > 0; y--)
        {
            for (int x = 0; x < gameBoardSize; x++)
            {
                Console.Write(gameBoard[y, x]);
            }
            Console.WriteLine();
        }
    }


    public void PlayerSetting() // 플레이어 가운데 세팅
    {
        int defultPos = gameBoardSize / 2;

        gameBoard[defultPos, defultPos] = '◆';
        playerPosX = playerPosY = defultPos;
    }


    public void InputKey() // 키 입력
    {
        if (Console.KeyAvailable)
        {
            inputKey = Console.ReadKey();
        }

        MovePlayer(inputKey.Key);
        if (isYesInput == false)
        {
            MovePlayer(lastKeyInPut);
        }

        EatFoods();
        isYesInput = false;
    }


    void MovePlayer(ConsoleKey keyCode)
    {
        switch (keyCode)
        {
            case ConsoleKey.UpArrow:
                playerPosY++;
                lastKeyInPut = keyCode;
                isYesInput = true;
                break;
            case ConsoleKey.DownArrow:
                playerPosY--;
                lastKeyInPut = keyCode;
                isYesInput = true;
                break;
            case ConsoleKey.RightArrow:
                playerPosX++;
                lastKeyInPut = keyCode;
                isYesInput = true;
                break;
            case ConsoleKey.LeftArrow:
                playerPosX--;
                lastKeyInPut = keyCode;
                isYesInput = true;
                break;
        }
    }


    public void MakeFood()
    {
        if (isAliveFood == true)
        {
            return;
        }

        while (true)
        {
            Random random = new Random();
            int X = random.Next(1, gameBoardSize - 1);
            int Y = random.Next(1, gameBoardSize - 1);

            if (gameBoard[Y, X] == '□')
            {
                gameBoard[Y, X] = '★';
                isAliveFood = true;
                break;
            }
        }
    }


    public void EatFoods()
    {
        if (gameBoard[playerPosY, playerPosX] == '★')
        {
            eatFood++;
            Console.WriteLine("먹은 음식" + eatFood);
            tails.Add(new List<int>());
            tails[tails.Count - 1].Add(0);
            tails[tails.Count - 1].Add(0);

            isAliveFood = false;
        }
    }


    public void InputSneakTails()
    {
        for (int num = tails.Count - 1; num > 0; num--)
        {
            tails[num][0] = tails[num - 1][0];
            tails[num][1] = tails[num - 1][1];

            gameBoard[(tails[num][0]), (tails[num][1])] = '■';
        }
        tails[0][0] = playerPosY;
        tails[0][1] = playerPosX;
        gameBoard[(tails[0][0]), (tails[0][1])] = '◆';
    }

    public bool CheckGameOver()
    {
        if ((playerPosX == 0 || playerPosX == gameBoardSize - 1) || (playerPosY == 0 || playerPosY == gameBoardSize - 1))
        {
            IsGameOver = true;
        }
        for (int num = 1; num < tails.Count; num++)
        {
            if (tails[0][0] != tails[num][0])
            {
                continue;
            }
            if (tails[0][1] != tails[num][1])
            {
                continue;
            }

            IsGameOver = true;
        }

        if (IsGameOver == true)
        {
            return true;
        }
        return false;
    }
}
