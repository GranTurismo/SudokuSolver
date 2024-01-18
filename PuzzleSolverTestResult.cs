public static class Puzzles
{
    public static PuzzleSolverTestResult Check(Func<string, string> solver)
    {
        var failedCount = 0;
        var passedCount = 0;

        var averageTime = 0d;
        var minTime = 0d;
        var maxTime = 0d;

        var iterations = 0;

        foreach (var puzzle in Enumerate())
        {
            var input = puzzle.Input;
            var startTime = DateTime.Now;
            var outPut = solver(input);
            var endTime = DateTime.Now;

            if (outPut == puzzle.Output)
                passedCount++;
            else
                failedCount++;

            var time = (endTime - startTime).TotalMilliseconds;

            minTime = Math.Min(time, minTime);
            maxTime = Math.Max(time, maxTime);

            averageTime = (averageTime * iterations + time) / ++iterations;
        }


        return new PuzzleSolverTestResult(failedCount, passedCount, averageTime, minTime, maxTime);
    }

    public static IEnumerable<Puzzle> Enumerate()
    {
        yield return new Puzzle("070000043040009610800634900094052000358460020000800530080070091902100005007040802", "679518243543729618821634957794352186358461729216897534485276391962183475137945862");
    }

    public readonly struct Puzzle
    {
        public readonly string Input;
        public readonly string Output;

        public Puzzle(string input, string output)
        {
            Input = input;
            Output = output;
        }
    }

    public readonly struct PuzzleSolverTestResult
    {
        public readonly int FailedCount;
        public readonly int PassedCount;

        public readonly double AverageTime;
        public readonly double MinTime;
        public readonly double MaxTime;

        public PuzzleSolverTestResult(int failedCount, int passedCount, double averageTime, double minTime, double maxTime)
        {
            FailedCount = failedCount;
            PassedCount = passedCount;

            AverageTime = averageTime;
            MinTime = minTime;
            MaxTime = maxTime;
        }
    }
}