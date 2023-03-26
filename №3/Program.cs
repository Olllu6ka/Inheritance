using System;

namespace _3
{
    //Используя Visual Studio, создайте проект по шаблону Console Application.
    //Требуется: Создать класс, представляющий учебный класс ClassRoom.Создайте класс ученик
    //Pupil.В теле класса создайте методы void Study(), void Read(), void Write(), void Relax(). Создайте 3
    //производных класса ExcelentPupil, GoodPupil, BadPupil от класса базового класса Pupil и
    //переопределите каждый из методов, в зависимости от успеваемости ученика.Конструктор
    //класса ClassRoom принимает аргументы типа Pupil, класс должен состоять из 4 учеников.
    //Предусмотрите возможность того, что пользователь может передать 2 или 3 аргумента.Выведите
    //информацию о том, как все ученики экземпляра класса ClassRoom умеют учиться, читать, писать,
    //отдыхать.
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            ClassRoom classRoom = new ClassRoom();
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Введите имя ученика {i+1}: ");
                string firstStudent = Console.ReadLine();
                student.GetSetM();
                student.GetSetR();
                student.GetSetW();
                student.GetSetRelax();
                classRoom.Mark(student.MarkSt, student.Read, student.Write);
                classRoom.Print(student.MarkSt, student.Read, student.Write,student.Relax,firstStudent);
            }

        }
    }
    class ClassRoom:Student
    {
        public void Mark(int Markst,int ReadSt,int WriteSt){
            int Mark = (MarkSt+ReadSt+WriteSt);
            if (Mark > 9)
            {
                Console.WriteLine("Ваш студент - Excelent ");
            }
            else if (Mark > 6)
            {
                Console.WriteLine("Ваш студент - Good ");
            }
            else if (Mark < 6)
            {
                Console.WriteLine("Ваш студент - Bad ");
            }
        }
        public void Print(int Markst, int ReadSt, int WriteSt,int Relax,string Student)
        {
            Console.WriteLine($" 10A - Ученик {Student}");
            Console.WriteLine($"{Markst} - Оценка ученика {Student}");
            Console.WriteLine($"{ReadSt} - Оценка ученика  {Student}");
            Console.WriteLine($"{WriteSt} - Оценка ученика {Student}");
            Console.WriteLine($"{Relax} - Оценка ученика  {Student}");
            Console.WriteLine("///////////////////////////////////////");
        }
        
    }
    public class Student
    {
        public int MarkSt;
        public int Read;
        public int Write;
        public int Relax;
        public void GetSetM(){
            Console.Write("Введите оценку по учебе ученика: ");
            int value  = int.Parse(Console.ReadLine());
            MarkSt = value;
        }
        public void GetSetR(){
            Console.Write("Введите оценку по чтению ученика: ");
            int value = int.Parse(Console.ReadLine());
            Read = value;
        }
        public void GetSetW(){
            Console.Write("Введите оценку по письму ученика: ");
            int value = int.Parse(Console.ReadLine());
            Write = value;
        }
        public void GetSetRelax(){
            Console.Write("Введите сколько ученик отдыхает за неделю дней: ");
            int value = int.Parse(Console.ReadLine());
            Relax = value;
        }
    }
}
