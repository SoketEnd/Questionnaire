using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {

        static (string Name, string MidlName, int Age, bool havPats, string[] namePats, string[] FavColor) GetUserData()
        {
            Console.WriteLine("Введите ваше имя");
            string Name = Console.ReadLine();

            Console.WriteLine("Введите вашу фамилию");
            string MidlName = Console.ReadLine();

            int Age = NumChek("Введите ваш возрост");

            bool havPats = PetsChek("У вас есть питомец ? (Да/Нет)");

            string[] namePats = havPats ? GetPetsName() : new string[0];

            int FavColorCount = NumChek("Сколько у вас любимых цветов ?");

            string[] FavColor = GetColorFavor(FavColorCount);

            return (Name, MidlName, Age, havPats, namePats, FavColor);
        }

        static int NumChek(string message)
        {
            int val;
            while(true)
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out val) && val > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка, введите коректное число!");
                }
            }
            return val;
        }

        static bool PetsChek(string message)
        {
            while(true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (input == "Да")
                {
                    return true;
                }
                else if (input == "Нет")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Введены неверные значения пожалуйста введите Да или Нет ");
                }
                
            }
        }

        static string[] GetPetsName()
        {
            int patsCount = NumChek("Сколько у вас питомцев");
            string[] petName = new string[patsCount];

            for (int i = 0; i < patsCount; i++)
            {
                Console.WriteLine($"Введите кличку питомца №{i + 1}");
                petName[i] = Console.ReadLine();
            }
            return petName;
        }

        static string[] GetColorFavor(int count)
        {
            string[] ColorNum = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите ваш любимый цвет №{i + 1}");
                ColorNum[i] = Console.ReadLine();
            }
            return ColorNum;
        }

        static void ShowUserData((string name, string surname, int age, bool hasPet, string[] petNames, string[] favoriteColors) UserData)
        {
            Console.WriteLine("Ваши данные:");
            Console.WriteLine($"Ваше имя: {UserData.name}");
            Console.WriteLine($"Ваша фамилия: {UserData.surname}");
            Console.WriteLine($"Ваш возрост: {UserData.age}");
            Console.WriteLine($"Наличие питомца {(UserData.hasPet ? "Да" : "Нет")}");
            if (UserData.hasPet)
            {
                Console.WriteLine($"Клички питомцев: {string.Join(", ", UserData.petNames)}");
            }
            Console.WriteLine($"Любимые цвета: {string.Join(", ", UserData.favoriteColors)}");
        }

        static void Main(string[] args)
        {
            var userData = GetUserData();
            ShowUserData(userData);
            Console.ReadKey();
        }
    }
}
