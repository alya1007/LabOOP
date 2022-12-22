namespace lab6.extensions {
    public static class ColoredConsole{
        public static void WriteColoredLineWithDelay(ConsoleColor color, object printable){
            Console.ForegroundColor = color;
            Console.Write(printable.ToString());
            Console.ResetColor();
            Thread.Sleep(Program.DELAY_TIME);
        }
        public static void WriteBlueLine(object printable){
            WriteColoredLineWithDelay(ConsoleColor.Blue, printable);
        }
        public static void WriteRedLine(object printable){
            WriteColoredLineWithDelay(ConsoleColor.Red, printable);
        }
        public static void WriteGreenLine(object printable){
            WriteColoredLineWithDelay(ConsoleColor.Green, printable);
        }
        public static void WriteYellowLine(object printable){
            WriteColoredLineWithDelay(ConsoleColor.Yellow, printable);
        }
        public static void WriteWhiteLine(object printable){
            WriteColoredLineWithDelay(ConsoleColor.White, printable);
        }
    }
}