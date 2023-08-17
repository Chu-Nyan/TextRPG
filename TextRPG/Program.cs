using System.Text;

//몬스터 이름 종류
enum MonsterName
{
    Goblin,
    Dragon
}

interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int Attck { get; set; }
    bool IsDead { get; set; }

    void TakeDamage(int damage);
}
interface IItem
{
    string Name { get; }

    void Use(Wrrior Wrrior);
}

class Wrrior : ICharacter
{
    string name = "츄냥";
    int health = 100;
    int attck = 10;
    bool isDead = false;

    //인벤토리 초기화
    public IItem[] Inven = new IItem[5] { new Nullitem(), new Nullitem(), new Nullitem(), new Nullitem(), new Nullitem() };

    public string Name { get { return name; } set { name = value; } }
    public int Health 
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0) // HP값이 0이하로 떨어지면 0으로 고정
            {
                health = 0;
                IsDead = true;
            }
        }
    }
    public int Attck { get { return attck; } set { attck = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    // 공격 받음
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    // 아이템 추가
    public void AddItem(IItem NewItem)
    {
        for (int num = 0; num < Inven.Length; num++)
        {
            if (Inven[num].Name == "없음")
            {
                Console.WriteLine($"{NewItem.Name}을 획득하였습니다.");
                Inven[num] = NewItem;
                break;
            }
            else if (num == Inven.Length - 1)
            {
                Console.WriteLine("인벤토리가 꽉 찼습니다.");
            }
        }
    }

    // 인벤토리 열어보기
    public void OpenInven()
    {
        Console.WriteLine();

        Console.Write($"0. 돌아가기 "); 
        for (int num = 0; num < Inven.Length; num++) // 인벤토리 내용물 출력
        {
            Console.Write($"{num + 1}. {Inven[num].Name}    ");
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("아이템을 선택해주세요.");
        Console.WriteLine();
        switch (Console.ReadKey(true).Key) // 인벤토리 선택
        {
            case ConsoleKey.D0:
                Console.WriteLine("가방을 닫습니다.");
                break;
            case ConsoleKey.D1:
                if (Inven[0].Name == "없음")
                {
                    Console.WriteLine("가방을 비어있습니다.");
                    break;
                }
                Inven[0].Use(this);
                Inven[0] = new Nullitem();
                break;
            case ConsoleKey.D2:
                if (Inven[1].Name == "없음")
                {
                    Console.WriteLine("가방을 비어있습니다.");
                    break;
                }
                Inven[1].Use(this);
                Inven[1] = new Nullitem();
                break;
            case ConsoleKey.D3:
                if (Inven[2].Name == "없음")
                {
                    Console.WriteLine("가방을 비어있습니다.");
                    break;
                }
                Inven[2].Use(this);
                Inven[2] = new Nullitem();
                break;
            case ConsoleKey.D4:
                if (Inven[3].Name == "없음")
                {
                    Console.WriteLine("가방을 비어있습니다.");
                    break;
                }
                Inven[3].Use(this);
                Inven[3] = new Nullitem();
                break;
            case ConsoleKey.D5:
                if (Inven[4].Name == "없음")
                {
                    Console.WriteLine("가방을 비어있습니다.");
                    break;
                }
                Inven[4].Use(this);
                Inven[4] = new Nullitem();
                break;
            default:
                break;
        }
        Thread.Sleep(2000);

    }
}

class Monster : ICharacter
{
    string name = "";
    int health;
    int attck;
    bool isDead = false;

    public string Name { get { return name; } set { name = value; } }
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                IsDead = true;
            }
        }
    }
    public int Attck { get { return attck; } set { attck = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}

class Goblin : Monster
{
    public Goblin()
    {
        Name = MonsterName.Goblin.ToString();
        Health = 20;
        Attck = 3;
    }
}

class Dragon : Monster
{
    public Dragon()
    {
        Name = MonsterName.Dragon.ToString();
        Health = 70;
        Attck = 10;
    }
}

// 몬스터따라 이미지 출력
class TextArt
{
    public static void Goblin()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" 　∧_∧         .∧∧ ");
        Console.WriteLine("　(r' ')r    　　(' ')/");
        Console.WriteLine("   / /     VS　ノ/  /");
        Console.WriteLine(" ノ￣>    　   ノ￣＞");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  You          Goblin");
        Console.WriteLine();
    }

    public static void Dragon()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("       　　 　      　 　    |＼_ /|  ");
        Console.WriteLine(" 　　 　 　　　|             |ㅇxㅇ|   ");
        Console.WriteLine(" 　∧_∧     　|＼＿＿＿＿＿／　 　| ");
        Console.WriteLine("　(r' ')r    　 |　　　 　C==　  　|  ");
        Console.WriteLine("   / /     VS　　＼　　　　　   　ノ　  ");
        Console.WriteLine(" ノ￣>    　   　　(/￣￣￣￣￣(/()");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  You                  Dragon");
        Console.WriteLine();
    }
}

// 빈 인벤토리
class Nullitem : IItem
{
    string name = "없음";
    public string Name { get { return name; } }

    public void Use(Wrrior Wrrior)
    {
    }
}

// 체력 회복 표션
class HealthPotion : IItem
{
    string name = "콩";
    public string Name { get { return name; } }

    public void Use(Wrrior Wrrior)
    {
        Wrrior.Health += 20;
        Console.WriteLine();
        Console.WriteLine("콩!!!!.");
        Console.WriteLine("체력 20을 회복하였습니다.");
        Console.WriteLine();
    }
}

// 힘 추가 포션
class StrengthPotion : IItem
{
    string name = "코옹";
    public string Name { get { return name; } }

    public void Use(Wrrior Wrrior)
    {
        Wrrior.Attck += 5;
        Console.WriteLine("공격력이 5 올랐습니다.");
    }
}

// 게임의 흐름을 제어
class Stage
{
    Wrrior wrrior;
    public Monster NewMonster;
    int StageLv = 1;

    //플레이어 캐릭터 생성자
    public Stage(Wrrior wrrior)
    {
        this.wrrior = wrrior;
    }

    //몬스터를 만들기
    void MakeMonster()
    {
        // 난이도 시스템
        // Dragon은 StageLv 3 이상에서 출현
        Random random = new Random(); 
        int makeRandomMonster = random.Next(0 + StageLv, 25);

        if (makeRandomMonster < 15)
        {
            NewMonster = new Goblin();
        }
        else if (makeRandomMonster < 25 && StageLv > 2)
        {
            NewMonster = new Dragon();
        }
        else { NewMonster = new Goblin(); }
    }

    // 스테이지 세팅 및 UI 출력
    public void EnterTheStage()
    {
        if (NewMonster == null || NewMonster.IsDead == true)
        {
            MakeMonster();
        }
        RenderUI();
    }

    // 스테이지, 캐릭터 상태 출력
    void RenderUI()
    {
        Console.Clear();

        StringBuilder StageTxt = new StringBuilder($"Stage. {StageLv} -------------------------");
        Console.WriteLine(StageTxt);
        StringBuilder StatusTxt = new StringBuilder("이름 : Name  / 체력 : Health / 공격력 : Attck");

        if (NewMonster.Name == MonsterName.Goblin.ToString())
        {
            TextArt.Goblin();
        }
        else
        {
            TextArt.Dragon();
        }

        StatusTxt.Replace("Name", NewMonster.Name);
        StatusTxt.Replace("Health", NewMonster.Health.ToString());
        StatusTxt.Replace("Attck", NewMonster.Attck.ToString());
        Console.WriteLine(StatusTxt);

        StatusTxt = new StringBuilder("이름 : Name  / 체력 : Health / 공격력 : Attck");
        StatusTxt.Replace("Name", wrrior.Name);
        StatusTxt.Replace("Health", wrrior.Health.ToString());
        StatusTxt.Replace("Attck", wrrior.Attck.ToString());
        Console.WriteLine(StatusTxt);
        Console.WriteLine();
    }

    // 플레이어 턴에 행동 선택
    public void RenderPlayerTurn()
    {
        Console.WriteLine("당신이 공격할 차례입니다.");
        Console.WriteLine();
        Console.WriteLine("1. 공포의 쓴맛!!");
        Console.WriteLine("2. 콩을 먹는다.");
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                Random random = new Random(); // 선공 후공 주사위 굴리기
                int diceFirstAtk = random.Next(0, 3);
                if (diceFirstAtk < 2)
                {
                    AttckPhase(wrrior, NewMonster);
                }
                else
                {
                    AttckPhase(NewMonster, wrrior);
                }
                break;
            case ConsoleKey.D2:
                wrrior.OpenInven();
                break;
            default:
                break;
        };

    }

    //턴 진행 인자값으로 선공 후공을 결정
    void AttckPhase(ICharacter firstAttcker, ICharacter secendAttcker)
    {
        secendAttcker.TakeDamage(firstAttcker.Attck);
        firstAttcker.TakeDamage(secendAttcker.Attck);
        RenderUI();
        Thread.Sleep(300);
        Console.WriteLine($"{firstAttcker.Name}은(는) 손날을 세웠다.\"공포의 쓴~~~맛!! 허야야야야야\" ");
        Thread.Sleep(1000);
        Console.WriteLine($"{secendAttcker.Name}은(는) {firstAttcker.Attck}의 피해를 입었다.");
        Console.WriteLine();
        Thread.Sleep(1500);
        Console.WriteLine($"{secendAttcker.Name}이(가) 아픔을 참고 반격하였다.");
        Thread.Sleep(1000);
        Console.WriteLine($"{firstAttcker.Name}는(은) {secendAttcker.Attck}의 피해를 입었다.");

        Thread.Sleep(3000);
    }

    // 결판이 났는지 확인
    public void TurnResult(ICharacter player, ICharacter newMonster)
    {
        // 플레이어가 죽었는지 확인
        if (player.IsDead == true)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("G ");
            Thread.Sleep(200);
            Console.Write("A ");
            Thread.Sleep(200);
            Console.Write("M ");
            Thread.Sleep(200);
            Console.Write("E ");
            Thread.Sleep(200);
            Console.Write("O ");
            Thread.Sleep(200);
            Console.Write("V ");
            Thread.Sleep(200);
            Console.Write("E ");
            Thread.Sleep(200);
            Console.Write("R ");
            Program.gameOver = true;
            Thread.Sleep(3000);
        }

        // 몬스터가 죽었는지 확인
        if (newMonster.IsDead == false)
        {
            return; // 죽지 않았으면 함수 종료
        }

        StageLv++; //난이도 증가

        // 이겼을 때 랜덤 대사 출력
        Random random = new Random();
        int pedigreeCase = random.Next(0, 2);
        StringBuilder heIsDead = new StringBuilder();
        Console.WriteLine();

        switch (pedigreeCase)
        {
            case 0:
                heIsDead.Append($"지난 달 결혼한 ");
                break;
            case 1:
                heIsDead.Append($"거동조차 힘든 노모를 혼자 보살피는 ");
                break;
        }
        heIsDead.Append($"{newMonster.Name}은 자연의 품으로 돌아갔다.");
        Console.WriteLine(heIsDead);

        Thread.Sleep(2000);

        switch (pedigreeCase)
        {
            case 0:
                Console.WriteLine($"아내의 뱃속에는 원한을 품은 사내가 꿈틀대고 있었다...");
                break;
            case 1:
                Console.WriteLine($"노모도 머지않아 {newMonster.Name}의 곁으로 갈 것이다.");
                break;
        }

        Thread.Sleep(2000);

        DropItem();

        Console.WriteLine($"다음 스테이지로 나아갑니다...");
        Console.WriteLine($"아무키나 입력해주세요.");
        Console.ReadKey();
    }

    // 아이템 드랍 & 자동 획득
    void DropItem()
    {
        Random randomItem = new Random();
        int itemNum = randomItem.Next(0, 3);

        Console.WriteLine();
        switch (itemNum)
        {
            case 0 :
                Console.WriteLine("시체를 뒤졌지만 아무 것도 없었다.");
                break;
            case 1 :
                wrrior.AddItem(new HealthPotion());
                break;
            case 2:
                wrrior.AddItem(new StrengthPotion());
                break;
            default:
                Console.WriteLine("switch (itemNum)");
                break;
        }
        Console.WriteLine();
    }
}

class Program
{
    public static bool gameOver = false;
    
    static void Main()
    {
        Wrrior wrrior = new Wrrior();
        Stage Stage = new Stage(wrrior);
        while (gameOver == false)
        {
            Stage.EnterTheStage();
            Stage.RenderPlayerTurn();
            Stage.TurnResult(wrrior, Stage.NewMonster);

        }
    }
}
