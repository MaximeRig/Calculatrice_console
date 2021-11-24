using System;

namespace Calculatrice_console {
    static class ConsoleIO {
        public static void write(string text) {
            Console.WriteLine(text);
        }

        public static string? read() {
            return Console.ReadLine();
        }
    }
}
