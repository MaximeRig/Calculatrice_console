using System;
using System.Globalization;
using Calculatrice_console;

namespace UserInterface
{
    public static class UserInterface
    {
        private static string _questionForNumber = "Veuillez saisir un nombre : ";
        private static string[] _operationTypeList = new string[4] { "a", "s", "m", "d" };
        private static string? _operationType;
        private static decimal _result = 0;
        private static decimal _num1;
        private static decimal _num2;

        public static void Start()
        {
            ConsoleIO.write("Bienvenue sur ma première application en C#: une calculatrice.");

            _num1 = GetNumber();

            AskForOperation();

            SetOperationType();

            _num2 = GetNumber();

            Calculate();

            ShowOperation();
            ShowResult();

        }

        private static void SetOperationType()
        {
            string? input = Console.ReadLine();
            while (!Array.Exists(_operationTypeList, el => el == input))
            {
                AskForOperation();
                input = Console.ReadLine();
            }

            _operationType = input;
        }

        private static void Calculate()
        {
            switch (_operationType)
            {
                case "a":
                    _result = _num1 + _num2;
                    break;
                case "s":
                    _result = _num1 - _num2;
                    break;
                case "m":
                    _result = _num1 * _num2;
                    break;
                case "d":
                    while (_num2 == 0)
                    {
                        ConsoleIO.write("Vous ne pouvez pas diviser par 0, veuillez choisir un autre nombre.");
                        string? input2 = Console.ReadLine();
                        while (!IsInputParsed(input2))
                        {
                            ConsoleIO.write(_questionForNumber);
                            input2 = ConsoleIO.read();
                        }
                        _num2 = Convert.ToDecimal(input2);
                    }
                    _result = _num1 / _num2;
                    break;
            }
        }

        private static void ShowResult()
        {
            ConsoleIO.write($"Résultat = {_result}");
        }

        private static int getIndexOfOperation()
        {
            return Array.IndexOf(_operationTypeList, _operationType);
        }

        private static void ShowOperation()
        {
            int index = getIndexOfOperation();

            ConsoleIO.write($"Opération : {_num1} {_num2}");
        }

        private static decimal GetNumber()
        {
            ConsoleIO.write(_questionForNumber);

            string? input = ConsoleIO.read();
            while (!IsInputParsed(input))
            {
                ConsoleIO.write(_questionForNumber);
                input = Console.ReadLine();
            }

            return Convert.ToDecimal(input);
        }

        private static void AskForOperation()
        {
            ConsoleIO.write("Veuillez choisir une opération :");
            ConsoleIO.write("\ttaper a pour faire une addition");
            ConsoleIO.write("\ttaper s pour faire une soustraction");
            ConsoleIO.write("\ttaper m pour faire une multiplication");
            ConsoleIO.write("\ttaper d pour faire une division");
        }

        private static bool IsInputParsed(string input)
        {
            return Decimal.TryParse(input, NumberStyles.Any, new CultureInfo("fr-FR"), out decimal result);
        }
    }
}
