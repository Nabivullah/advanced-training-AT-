namespace CS._3._017
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                // Task: Build LoadProfileDay with some zeros & highs
                var highLoadDay = new LoadProfileDay(
                    new DateTime(2025, 10, 1),
                    new List<double> { 10, 12, 15, 18, 22, 25, 28, 30, 35, 40, 45, 50, 48, 42, 38, 33, 29, 24, 20, 16, 13, 11, 9, 8 }
                ); // Total load > 500

                var outageDay = new LoadProfileDay(
                    new DateTime(2025, 10, 2),
                    new List<double> { 5, 6, 7, 0, 0, 0, 0, 0, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }
                ); // 5 consecutive zeros from hour 3

                var noTriggerDay = new LoadProfileDay(
                    new DateTime(2025, 10, 3),
                    new List<double> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                ); // Total load = 240, no outage

                var rules = new List<AlarmRule>
        {
            new PeakOveruseRule(threshold: 500), // Setting threshold for peak overuse
            new SustainedOutageRule(min: 4)      // Setting minimum consecutive hours for outage
        };

                // Task: Evaluate rules and print triggered messages
                EvaluateRules(highLoadDay, rules);
                EvaluateRules(outageDay, rules);
                EvaluateRules(noTriggerDay, rules);
            }

            public static void EvaluateRules(LoadProfileDay day, List<AlarmRule> rules)
            {
                Console.WriteLine($"--- Evaluating for {day.Date:yyyy-MM-dd} ---");
                foreach (var rule in rules)  //Checking each rule one by one
            {
                    if (rule.IsTriggered(day))
                    {
                        Console.WriteLine(rule.Message(day));
                    }
                }
                Console.WriteLine();
            }
        

    
}
}
