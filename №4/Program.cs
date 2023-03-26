using System;
using System.Linq;

namespace _4
{
    //Используя Visual Studio, создайте проект по шаблону Console Application.
    //Создайте программу, в которой создайте базовый класс Person(человек), в классе создайте поле
    //типа int с именем BirthYear(год рождения), поле типа string с именем Name и поле типа
    //string с именем Surname.Далее создайте классы Student (студент), Teacher (преподаватель). В
    //классе Student добавьте поле типа string[] с именем Study Courses (изучаемые курсы), свойство
    //(не авто свойство) для добавления(set) и получения(get) изучаемых курсов и метод
    //DisplayStudyСourses() с возвращаемым значением void который будет выводить на консоль все
    //предметы, максимальное количество изучаемых курсов = 3. В классе преподаватель создать поле
    //типа Student[] с именем StudentsArray, и свойство(не авто свойство) для добавления(set) и
    //получения(get) студентов.Создайте 5 экземпляров класса типа Student и инициализируйте их
    //произвольными значениями, и 2 экземпляра класса типа Teacher, инициализируйте их
    //произвольными значениями(для инициализации поля StudentsArray используйте уже созданные
    //экземпляры Student). Далее создайте класс PeopleInfo, в нем создайте поле типа Person[] с
    //именем PeopleArray и свойство(не авто свойство) для добавления(set) и получения(get) людей и
    //метод который будет выводить всех людей который есть в поле PeopleInfo в порядке возрастания
    //возраста.
    class Program
    {
        // Хотел бы узнать нюансы по поводу данного дз
        // А то я что-то не вдуплил и зачем мне курсы тут ? телеграм мой @seller_ip
        static void Main(string[] args)
        {
            Student student = new Student();
            for (int h = 0; h < 3; h++)
            {
                Console.Write("Введите курс студента: ");
                string Course = Console.ReadLine();
                student.Set(Course, h);
            } // Курсы
            student.DisplayStudyСourses();
            PeopleInfo peopleInfo = new PeopleInfo();
            for (int c = 1; c < 6; c++)
            {
                Console.Write("Введите имя студента: ");
                string NameM = Console.ReadLine();
                Console.Write("Введите фамилию студента: ");
                string SurnameM = Console.ReadLine();
                peopleInfo.SetStudentArray(NameM, SurnameM,(c-1));
                Console.Write("Введите возраст студента: ");
                int BirthYear = int.Parse(Console.ReadLine());
                peopleInfo.Set(BirthYear,(c-1));
                Console.Clear();
            }
            peopleInfo.SetCoppyStudent();
            for (int h = 5; h < 7; h++)
            {
                Console.Write("Введите имя учителя: ");
                string NameM = Console.ReadLine();
                Console.Write("Введите фамилию учителя: ");
                string SurnameM = Console.ReadLine();
                peopleInfo.SetStudentArray(NameM, SurnameM,h);
                Console.Write("Введите возрacт учителя: ");
                int BirthYear = int.Parse(Console.ReadLine());
                peopleInfo.Set(BirthYear,h);
                Console.Clear();
            }
            peopleInfo.SetCoppyStudent();
            Console.WriteLine("Информация про учителей и студентов !");
            peopleInfo.GetPrint();
        }
    }
    class Person
    {
        public int BirthYear;
        public string Name;
        public string Surname;
    }
    class Student:Person
    {
        public string[] StudyCourses = new string[3];
        public void Set(string Course,int g){
            StudyCourses[g] = Course;
        }   
        void Get()
        {
            for (int i = 0; i < StudyCourses.Length; i++)
            {
                Console.WriteLine(StudyCourses[i] + " - Курс");
            }
        }
        public void DisplayStudyСourses()
        {
            for (int i = 0; i < StudyCourses.Length; i++)
            {
                Console.WriteLine(StudyCourses[i] + " - Курс");
            }
        }
    }   
    class Teacher:Student
    {
        public string[,] StudentArray = new string[7,2];
        public int[] StudentBirthYear = new int[7];
        public void Set(int BirthYear,int a)
        {
            StudentBirthYear[a] = BirthYear;
        }
        public void GetStudentArray()
        {
            for (int i = 0; i < StudentArray.GetLength(0); i++)
            {
                for (int g = 0; g < StudentArray.GetLength(1); g++)
                {
                    Console.WriteLine(StudentArray[i,g] + " - Студенты");
                }
            }
        }
        public void SetStudentArray(string Name, string Surname,int Inter)
        {
            for (int i = -1; i < Inter; i++)
            {
                StudentArray[Inter, 0] = Name;
                for (int g = 1; g < 2; g++)
                {
                    StudentArray[Inter,g] = Surname;  
                }
            }
        } 
    }
    class PeopleInfo:Teacher
    {
        public string[,] PersonMs = new string[7,2];
        public void GetPrint(){
            int currentMin = int.MinValue;
            for (int i = 0; i < StudentBirthYear.Length; i++){
                int current = int.MaxValue;
                int minCount = 0;
                for (int j = 0; j < StudentBirthYear.Length; j++){
                    if (StudentBirthYear[j] < current && StudentBirthYear[j] > currentMin){
                        current = StudentBirthYear[j];
                        minCount = 0;
                    }
                    if (StudentBirthYear[j] == current)
                        minCount++;
                }
                while (minCount-- > 0)
                    for (int k = 0; k < StudentBirthYear.Length; k++){
                        if (StudentBirthYear[k] == current){
                            Console.WriteLine($"Имя - {PersonMs[k, 0]} = Фамилия - {PersonMs[k, 1]} = Год рождения - {StudentBirthYear[k]}");
                        }
                    }
                currentMin = current;
            }
        }
        public void SetCoppyStudent()
        {
            PersonMs = StudentArray.Clone() as string[,];
        }
    }
}
