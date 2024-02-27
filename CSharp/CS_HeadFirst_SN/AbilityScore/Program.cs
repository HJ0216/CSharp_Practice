namespace AbilityScore
{
    internal class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DevideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DevideBy = ReadDouble(calculator.DevideBy, "Divided By");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add Amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");

                calculator.CalculateAbilitySocre();

                Console.WriteLine("Calcuated ability Score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");

                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        /// <summary>
        /// 메시지를 출력하고 콘솔에서 int 값을 읽어 들입니다.
        /// </summary>
        /// <param name="defaultValue">기본값</param>
        /// <param name="message">콘솔에 출력할 메시지</param>
        /// <returns>읽어 들인 double 값 또는 변환이 불가능할 때는 기본값</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static double ReadDouble(double defaultValue, string message)
        {
            Console.Write(message + "[" + defaultValue + "]: ");
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine("using default value " + defaultValue);
                return defaultValue;
            }
        }

        /// <summary>
        /// 메시지를 출력하고 콘솔에서 int 값을 읽어 들입니다.
        /// </summary>
        /// <param name="defaultValue">기본값</param>
        /// <param name="message">콘솔에 출력할 메시지</param>
        /// <returns>읽어 들인 int 값 또는 변환이 불가능할 때는 기본값</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int ReadInt(int defaultValue, string message)
        {
            Console.Write(message + "[" + defaultValue + "]: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine("using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine("using default value " + defaultValue);
                return defaultValue;
            }
        }

        public void CalculateAbilitySocre()
        {
            double devided = RollResult / DevideBy;
            int added = AddAmount + (int)devided;
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }

    }
}
