using System;

namespace Inheritance
{
    //Используя Visual Studio, создайте проект по шаблону Console Application.
    //Создайте программу, в которой создайте класс хвост, который содержит в себе поля длину хвоста
    //типа int и вид хвоста типа string, создать свойства доступа и конструктор пользовательский
    //класса.Создать класс хвостатое животное, содержащий хвост, цвет(строка), возраст.Определить
    //public - производный класс собака, имеющий дополнительный параметр-кличку(строка).
    //В классе собака создать метод для отображения полной информации о собаке.
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите возаст собаки: ");
            int AgeM = int.Parse(Console.ReadLine());
            Console.Write("Введите Цвет собаки: ");
            string ColorM = Console.ReadLine();
            Console.Write("Введите Длина хвоста: ");
            int LenghtM = int.Parse(Console.ReadLine());
            Console.Write("Введите Название хвоста: ");
            string ViewM = Console.ReadLine();
            Console.Write("Введите Кличку собаки: ");
            string NickM = Console.ReadLine();
            Dog dog = new Dog() { age = AgeM, color = ColorM, length = LenghtM, nickname = NickM, viewLenght = ViewM };
            dog.Prrint(dog);
        }

    }
    public class Tail {
        public int length { get; set; }
        public string viewLenght { get; set; }
    }
    public class TailedAnimal : Tail{
        public string color { get; set; }
        public int age { get; set; }
    }
    public class Dog : TailedAnimal
    {
        public string nickname { get; set; }

        public void Prrint(Dog dog ){
            Console.WriteLine($"{dog.age} - Возаст собаки");
            Console.WriteLine($"{dog.color} - Цвет собаки");
            Console.WriteLine($"{dog.length} - Длина хвоста");
            Console.WriteLine($"{dog.viewLenght} - Название хвоста");
            Console.WriteLine($"{dog.nickname} - Кличка собаки");
        }
    }
}