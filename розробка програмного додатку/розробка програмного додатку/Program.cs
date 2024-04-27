using System.Text;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Text;

// Клас, що представляє готель
public class Hotel
{
    // Конструктор класу Hotel
    public Hotel(int number, int etage, string type, int cost, string[] client, string[] worker)
    {
        // Ініціалізація властивостей
        this.number = number;
        this.type = type;
        this.etage = etage;
        this.cost = cost;
        this.client = client;
        this.worker = worker;
    }
    // Властивості класу Hotel
    public int number { get; set; }
    public string type { get; set; }
    public int etage { get; set; }
    public int cost { get; set; }
    public string[] client { get; set; }
    string[] worker { get; set; }

    // Перевизначений метод ToString для виведення інформації про об'єкт у рядок
    public override string ToString() => $"Номер кімнати: {number}, поверх: {etage}, тип номера: {type}," +
        $"вартість: {cost}, клієнти: {string.Join(" ", client)}, працівники: {string.Join(" ", worker)}. ";
}

// Клас, що представляє відвідувача готелю
public class Visitor
{
    public Visitor(int ID, string name, int passNum, string home, int roomNum, int place, string startDay, int days)
    {
        this.ID = ID;
        this.name = name;
        this.passNum = passNum;
        this.home = home;
        this.roomNum = roomNum;
        this.startDay = startDay;
        this.days = days;
        this.place = place;

    }
    public int ID { get; set; }
    public string name { get; set; }
    public int passNum { get; set; }
    public string home { get; set; }
    public int roomNum { get; set; }
    public int place { get; set; }
    public string startDay { get; set; }
    public int days { get; set; }

    // Перевизначений метод ToString для виведення інформації про об'єкт у рядок
    public override string ToString() => $"Ключ: {ID}, П.І.Б.: {name}, паспорт: {passNum}, місто: {home}," +
        $" кімната :{roomNum}, місце :{place}, день візиту: {startDay}, платити за {days} день (дні). ";
}

// Клас, що представляє працівника готелю
public class Worker
{
    // Конструктор класу Worker
    public Worker(int ID, string name, string[] floor, string[] weekDay)
    {
        // Ініціалізація властивостей
        this.ID = ID;
        this.name = name;
        this.floor = floor;
        this.weekDay = weekDay;
    }
    // Властивості класу Worker
    public int ID { get; set; }
    public string name { get; set; }
    public string[] floor { get; set; }
    public string[] weekDay { get; set; }

    // Перевизначений метод ToString для виведення інформації про об'єкт у рядок
    public override string ToString() => $"ID: {ID}, П.І.П: {name}, список поверхів: {string.Join(" ", floor)}, список днів тижня: {string.Join(" ", weekDay)}.";
}
// Клас програми
public class Program
{
    // Метод для ініціалізації списку готелів
    static List<Hotel> InitRoom()
    {
        List<Hotel> hotel = new List<Hotel>() { };
        StreamReader fileReader = new StreamReader("C:\\Мясо\\Курсовая\\розробка програмного додатку\\розробка програмного додатку\\Hotel.txt", Encoding.Default);

        // Зчитування даних з файлу і створення об'єктів класу Hotel
        while (!fileReader.EndOfStream)
        {
            string[] lineParts = fileReader.ReadLine().Split(";");
            int number = Convert.ToInt32(lineParts[0]);
            int floor = Convert.ToInt32(lineParts[1]);
            int cost = Convert.ToInt32(lineParts[3]);
            string[] client = lineParts[4].Split(",");
            string[] worker = lineParts[5].Split(",");


            hotel.Add(new Hotel(number, floor, lineParts[2], cost, client, worker));
        }
        fileReader.Close();
        return hotel;
    }

    // Метод для ініціалізації списку відвідувачів
    static List<Visitor> InitVis()
    {
        List<Visitor> visitor = new List<Visitor>() { };
        StreamReader fileReader = new StreamReader("C:\\Мясо\\Курсовая\\розробка програмного додатку\\розробка програмного додатку\\Visitor.txt", Encoding.Default);

// Зчитування даних з файлу і створення об'єктів класу Visitor
        while (!fileReader.EndOfStream)
        {
            string[] lineParts = fileReader.ReadLine().Split(";");
            int number = Convert.ToInt32(lineParts[0]);


            visitor.Add(new Visitor(number, lineParts[1], int.Parse(lineParts[2]), lineParts[3], int.Parse(lineParts[4]), int.Parse(lineParts[5]), lineParts[6], int.Parse(lineParts[7])));
        }
        fileReader.Close();
        return visitor;
    }

    // Метод для ініціалізації списку працівників
    static List<Worker> InitWork()
    {
        List<Worker> worker = new List<Worker>() { };
        StreamReader fileReader = new StreamReader("C:\\Мясо\\Курсовая\\розробка програмного додатку\\розробка програмного додатку\\Worker.txt", Encoding.Default);

        // Зчитування даних з файлу і створення об'єктів класу Worker
        while (!fileReader.EndOfStream)
        {

            string[] lineParts = fileReader.ReadLine().Split(";");
            int number = Convert.ToInt32(lineParts[0]);
            string[] floor = lineParts[2].Split(",");
            string[] days = lineParts[3].Split(",");


            worker.Add(new Worker(number, lineParts[1], floor, days));
        }
        fileReader.Close();
        return worker;
    }

    // Метод для виведення інформації про номери готелю
    static void SeeHotel(List<Hotel> h)
    {
        foreach (Hotel room in h)
        {
            Console.WriteLine(room);
        }
    }

    // Метод для виведення інформації про працівників готелю
    static void SeeWorker(List<Worker> w)
    {
        foreach (Worker worker in w)
        {
            Console.WriteLine(worker);
        }
    }

    // Метод для виведення інформації про відвідувачів готелю
    static void SeeVisitor(List<Visitor> v)
    {
        foreach (Visitor client in v)
        {
            Console.WriteLine(client);
        }
    }

    // Метод для визначення вартості місця в номері
    static void PlaceCost(List<Hotel> hotel)
    {
        Console.WriteLine("Який номер вас цікавить: ");
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < hotel.Count; i++)
        {
            if (hotel[i].number == num)
            {
                string[] size = hotel[i].type.Split("-");
                int places = int.Parse(size[0]);
                Console.WriteLine($"Вартість місця - {hotel[i].cost / places}");
            }
        }
    }

    // Метод для визначення відвідувачів з певного міста
    static void FromCity(List<Visitor> visitors)
    {
        int checker = 0;
        Console.WriteLine("З якого міста вам потрібен клієнт: ");
        string city = Console.ReadLine();
        for (int i = 0; i < visitors.Count; i++)
        {
            if (visitors[i].home.ToLower() == city.ToLower())
            {
                checker = 1;
                Console.WriteLine("З цього міста - " + visitors[i].name);
            }
        }
        if (checker == 0) { Console.WriteLine("У нас не було жодного клієнта біля цього місця!"); }
    }

// Метод для визначення працівників, які прибирають кімнату клієнта
    static void CleaningByNameNDay(List<Visitor> visitors, List<Worker> workers)
    {
        int floor = 0;
        int check = 0;
        Console.WriteLine("Введіть ім'я: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть день тижня: ");
        string weekday = Console.ReadLine();
        for (int i = 0; i < visitors.Count; i++)
        {
            if (visitors[i].name.ToLower() == name.ToLower())
            {
                check = 1;
                floor = visitors[i].roomNum;
                break;
            }
        }
        if (floor >= 10) { floor /= 10; }
        for (int j = 0; j < workers.Count; j++)
        {
            foreach (string floors in workers[j].floor)
            {
                int k = int.Parse(floors);
                if (k == floor)
                {
                    foreach (string day in workers[j].weekDay)
                    {
                        if (day.ToLower() == weekday.ToLower()) { Console.WriteLine($"Кімната була прибрана {workers[j].name}"); check = 1; }
                    }
                }
            }
        }
        if (check == 0) { Console.WriteLine("Помилка"); }
    }


    // Метод для визначення кількості вільних місць та кімнат в готелі
    static void FreeRoom(List<Hotel> hotels)
    {
        int clearRoom = 0;
        int freePlace = 0;
        for (int i = 0; i < hotels.Count; i++)
        {
            int roomCheck = 0;
            foreach (string visitor in hotels[i].client)
            {
                if (visitor == "-") { freePlace++; }
                if (visitor != "-") { roomCheck = 1; }
            }
            if (roomCheck == 0) { clearRoom++; }
        }
        Console.WriteLine($"Порожнє місце - {freePlace}, порожня кімната - {clearRoom}");
    }

    // Метод для виведення інформації про клієнтів в одномісних номерах
    static void OnePlaceRoom(List<Hotel> hotels)
    {
        Console.WriteLine("Всі люди в 1-місному номері: ");
        for (int i = 0; i < hotels.Count; i++)
        {
            if (hotels[i].type == "одномісна") { Console.WriteLine(string.Join("", hotels[i].client)); }
        }
    }

    // Метод для розрахунку загального доходу від усіх клієнтів
    static void AllIncome(List<Hotel> hotel)
    {
        int summary = 0;
        for (int i = 0; i < hotel.Count; i++)
        {
            foreach (string s in hotel[i].client)
            {
                if (s != "-")
                {
                    string[] size = hotel[i].type.Split("-");
                    int placeCost = hotel[i].cost / int.Parse(size[0]);
                    summary += placeCost;
                }
            }
        }
        Console.WriteLine($"Весь дохід - {summary}");
    }

    // Метод для видалення працівника за ім'ям
    static List<Worker> Remove(List<Worker> workers)
    {
        Console.WriteLine("Введіть ім'я працівника для видалення. (І.І.Іванов):");
        string name = Console.ReadLine();
        var workerToRemove = workers.FirstOrDefault(w => w.name == name);

        if (workerToRemove != null)
        {
            workers.Remove(workerToRemove);
            Console.WriteLine($"{name} було видалено.");
        }
        else
        {
            Console.WriteLine($"Працівник з ім'ям {name} не знайдено.");
        }
        return workers;
    }

    // Метод для додавання нового працівника в список працівників
    static List<Worker> Add(List<Worker> workers)
    {
        int id = workers[workers.Count - 1].ID + 1;
        Console.WriteLine("Введіть нове ім'я працівника: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть нові робочі поверхи для роботи. (1,2,3): ");
        string[] floors = Console.ReadLine().Split(",");
        Console.WriteLine("Введіть нові робочі дні для роботи. (Субота, вівторок)");
        string[] days = Console.ReadLine().Split(",");
        workers.Add(new Worker(id, name, floors, days));
        return workers;
    }

// Основний метод програми
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Hotel> hotel = InitRoom();
        List<Worker> worker = InitWork();
        List<Visitor> visitor = InitVis();
        int a = -1;

        // Основний цикл програми
        while (a != 0)
        {
            Console.WriteLine("Що вам потрібно побачити: \n" +
                "1)Всі номери в готелях \n" +
                "2)Всі працівники готелю \n" +
                "3)Всі відвідувачі готелю \n" +
                "4)Вартість місця в номері \n" +
                "5)Клієнт з міста \n" +
                "6)Хто з працівників прибирає кімнату клієнта \n" +
                "7)Всі вільні місця та кімнати \n" +
                "8)Всі клієнти з одномісного номера \n" +
                "9)Дохід від усіх клієнтів \n" +
                "10)Видалити працівника \n" +
                "11)Додати працівника \n" +
                "0)ВИХІД");
            a = Convert.ToInt32(Console.ReadLine());

            // Обробка вибору користувача
            switch (a)
            {
                case 1:
                    SeeHotel(hotel);
                    break;
                case 2:
                    SeeWorker(worker);
                    break;
                case 3:
                    SeeVisitor(visitor);
                    break;
                case 4:
                    PlaceCost(hotel);
                    break;
                case 5:
                    FromCity(visitor);
                    break;
                case 6:
                    CleaningByNameNDay(visitor, worker);
                    break;
                case 7:
                    FreeRoom(hotel);
                    break;
                case 8:
                    OnePlaceRoom(hotel);
                    break;
                case 9:
                    AllIncome(hotel);
                    break;
                case 10:
                    Remove(worker);
                    break;
                case 11:
                    Add(worker);
                    break;
                case 0:
                    Console.WriteLine("Гарного дня!");
                    break;
            }
        }
    }
}