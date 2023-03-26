using System;

namespace _2
{
    //Используя Visual Studio, создайте проект по шаблону Console Application.
    //Создайте программу, в которой создайте базовый класс Shape(фигура), который содержит в себе
    //поле типа double c именем Volume и метод типа double GetVolume() который должен вернуть
    //объём фигуры.Далее создайте классы: Pyramid(пирамида), Cylinder(цилиндр), Ball(шар),
    //которые будут наследоваться от класса Shape, реализуйте в каждом из них метод для
    //нахождения объёма.Создайте класс Box (ящик) – он является контейнером, может содержать в
    //себе другие фигуры. В классе Box создайте поле типа double с именем DrawerVolume (Объем
    //ящика), поле должно хранить в себе объём ящика.Далее в классе Box создайте методАdd(),
    //который принимает на вход объекты типа Shape, и возвращает значение типа boll.В классе Box
    //реализуйте логику для добавления новых фигуры до тех пор, пока для них хватает места в Box
    //(будем считать только объём, игнорируя форму, например, мы переливаем жидкость). Если
    //места для добавления новой фигуры не хватает, то метод должен вернуть false.
    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            Console.Write("Введите размер вашего бокса: ");
            box.DrawerVolume = double.Parse(Console.ReadLine());
            for (;;)
            {
                Console.Write("Введите вашу фигру: ");
                string FigureName = Console.ReadLine();
                switch (FigureName)
                {
                    case "Пирамида":
                        Console.Write("Введите  S вашей фигуры: ");
                        double SmainP = double.Parse(Console.ReadLine());
                        Console.Write("Введите  H вашей фигуры: ");
                        double HmainP = double.Parse(Console.ReadLine());
                        Pyramid pyramid = new Pyramid { S = SmainP, H = HmainP };
                        pyramid.Vp();
                        double FigureeM = pyramid.Figure;
                        box.Add(FigureeM,"Пирамиды");
                        break;
                    case "Цилиндр":
                        Console.Write("Введите  S вашей фигуры: ");
                        double SmainC = double.Parse(Console.ReadLine());
                        Console.Write("Введите  H вашей фигуры: ");
                        double HmainC = double.Parse(Console.ReadLine());
                        Cylinder cylinder = new Cylinder { S = SmainC, H = HmainC };
                        cylinder.Vc();
                        double FigureeM1 = cylinder.Figure;
                        box.Add(FigureeM1,"Цилиндра");
                        break;
                    case "Шар":
                        Console.Write("Введите  R вашей фигуры: ");
                        double Rmain = double.Parse(Console.ReadLine());
                        Ball ball = new Ball { R = Rmain };
                        ball.Vb();
                        double FigureeM2 = ball.Figure;
                        box.Add(FigureeM2,"Шара");
                        break;
                }
                if (box.DrawerVolume < 0)
                {
                    break;
                }
            }
        }
    }
    public class Shape
    {
        
        public double Figure { get; set; }
        public double PI = 3.14;
        public double S { get; set; }
        public double H { get; set; }
        public double R { get; set; }
        
    }
    class Pyramid : Shape
    {
        public void Vp()
        {
            double V = (S * H) / 3;
            Figure = V; 
        }
    }
    class Cylinder : Shape
    {
        public void Vc()
        {
            double V = S * H;
            Figure = V;
        }
    }
    class Ball : Shape
    {
        public void Vb()
        {
            double V = (4 * (PI * (((R) * R) * R))) / 3;
            Figure = V;
        }
    }
    public class Box : Shape
    {
        public double DrawerVolume;
        public double Howmany;
        public void Add(double Figue,string FrigureName){
            Console.Write("Введите сколько предметов вы хотите поместить в бокс ? ");
            Howmany = double.Parse(Console.ReadLine());
            for (int i = 0; i < Howmany; i++){
                if (DrawerVolume < 0){
                    Console.WriteLine("Нету места в боксе !!");
                    break;
                }
                DrawerVolume = DrawerVolume - Figue;
                Console.WriteLine($"Положил {i + 1} фигуру {FrigureName}");
            }
        }
    }
}
