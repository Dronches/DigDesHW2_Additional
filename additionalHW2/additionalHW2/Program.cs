using System;

namespace additionalHW2
{
    /// <summary>
    /// абстрактный класс программиста (программист - широкое понятие)
    /// </summary>
    abstract class Programmer {
        /// <summary>
        /// Поля наименования программиста - имя, фамилия
        /// </summary>
        public string firstName;
        public string secondName;


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Programmer(string secondName, string firstName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Programmer () {
            this.firstName = "Андрей";
            this.secondName = "Петров";
        } 

        /// <summary>
        /// Напечатать строку, содержащую полное имя
        /// </summary>
        public void printFullName()
        {
            Console.WriteLine(this.getFullName());
        }

        /// <summary>
        /// Вернуть строку полного имени
        /// </summary>
        public string getFullName()
        {
            return this.secondName + " " + this.firstName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // получаем метод Allocate из класса RuntimeTypeHandle для прямой реализации абстрактного метода
            var allocateObject = typeof(RuntimeTypeHandle).GetMethod("Allocate", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            /// <summary>
            /// КОНСТРУТОР ПО УМОЛЧАНИЮ
            /// <summary>
            // получаем объект абстрактного класса программиста
            var programmerObject = (Programmer)allocateObject.Invoke(null, new object[] { typeof(Programmer) });
            // получаем конструктор по умолчанию
            var ctorPrigrammerObject = typeof(Programmer).GetConstructor(Type.EmptyTypes);
            // Применяем конструктор по умолчанию к объекту programmerObject
            var ctorDefaultProgrammer = ctorPrigrammerObject.Invoke(programmerObject, new object[0]); 
            // Выводим значения переменных
            Console.WriteLine(programmerObject.firstName);
            Console.WriteLine(programmerObject.secondName); 
            // выполняем встроенную функцию абстрактного класса
            programmerObject.printFullName();

            /// <summary>
            /// КОНСТРУТОР С ПАРАМЕТРАМИ
            /// <summary>
            // получаем объект абстрактного класса студента
            var programmerObject2 = (Programmer)allocateObject.Invoke(null, new object[] { typeof(Programmer) });
            // получаем конструктор с параметрами
            var ctorParamsObject2 = typeof(Programmer).GetConstructor(new Type[2] { typeof(string), typeof(string) });
            // Применяем конструктор с параметрами к объекту programmerObject2
            var ctorParamsProgrammer = ctorParamsObject2.Invoke(programmerObject2, new object[2] {"Бондаренко", "Андрей"});
            // Выводим значения переменных
            Console.WriteLine(programmerObject2.firstName);
            Console.WriteLine(programmerObject2.secondName);
            // выполняем встроенную функцию абстрактного класса получения имени
            string fullName = programmerObject2.getFullName();
            // производим вывод строки
            Console.WriteLine("Полное имя: {0}", fullName);

            // абстрактный метод абстрактного класса вызвать не получится - ведь он не имеет тела на данном этапе,
            // возможен вызов абстрактного метода только у наследников
        }
    }
}
