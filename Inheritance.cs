namespace BestPractices
{
    public class Inheritance : IDemo
    {
        public string Description => "Inheritance Demo ( Hiding )";

        public void Execute()
        {
            Hiding.MainMethod();
        }

        public class SingleInheritance
        {
            public class Employee
            {
                public int Experience { get; set; }

                public void CalculateSalary()
                {
                    int salary = Experience * 300000;

                    Console.WriteLine("salary:{0} ", salary);
                }
            }

            public class PermanentEmployee : Employee
            {
                // No method or Property here
            }

            public static void Example()
            {
                PermanentEmployee pEmployee = new PermanentEmployee();
                pEmployee.Experience = 5;
                pEmployee.CalculateSalary();

                Console.ReadLine();
            }
        }
        
        public class MultipleInheritance
        {
            public class BaseClass
            {
                public void Animal()
                {
                    Console.WriteLine("Animal");
                }
            }

            public interface IClass
            {
                public void Fly();
            }

            public class DerivedClass : BaseClass, IClass
            {
                public void Fly()
                {
                    Console.WriteLine("Fly");
                }

                public void Eagle()
                {
                    Console.WriteLine("Eagle");

                    base.Animal();
                }
            }
        }

        public class MultiLevelInheritance
        {
            public class BaseClass
            {
                public void Animal()
                {
                    Console.WriteLine("Animal");
                }
            }

            public class DerivedClass : BaseClass
            {
                public void Dog()
                {
                    Console.WriteLine();
                }
            }

            public class DerivedClass2 : DerivedClass
            {
                public void Labrador()
                {
                    Console.WriteLine();

                    base.Dog();
                    base.Animal();
                }
            }
        }

        public static class Hiding
        {
            public class BaseClass
            {
                public void Display()
                {
                    Console.WriteLine("Display method in BaseClass");
                }
            }

            public class DerivedClass : BaseClass
            {
                public new void Display()
                {
                    Console.WriteLine("Display method in DerivedClass");
                }
            }

            public class BaseClass2
            {
                public void Display()
                {
                    Console.WriteLine("Display method in BaseClass");
                }
            }

            public class DerivedClass2 : BaseClass2
            {
                public void Display()
                {
                    Console.WriteLine("Display method in DerivedClass");
                }
            }

            public static void MainMethod()
            {
                var baseClass = new BaseClass();
                var derivedClass = new DerivedClass();

                baseClass.Display();
                derivedClass.Display();

                var baseClass2 = new BaseClass();
                var derivedClass2 = new DerivedClass();

                baseClass2.Display();
                derivedClass2.Display();
            }
        }
    }
}
