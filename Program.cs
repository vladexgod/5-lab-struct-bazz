using System;
using System.Diagnostics;

namespace lab5
{
    class Program
    {
       static bool CheckContains(string word, string writtenWord)
        {
            bool result = false;
            int identity = 0;
            int cycleTimer = word.Length > writtenWord.Length ? cycleTimer = writtenWord.Length : cycleTimer = word.Length;
            _ = cycleTimer == 3;
            for (int i = 0; i < cycleTimer; i++)
            {
                if (writtenWord[i] == word[i])
                {
                    result = true;
                    identity++;
                }
                else
                {
                    result = false;
                    identity--;
                }
            }
            result = result == true && identity == cycleTimer;
            return result;
        }
        static void Main()  
        {
           string path = "WARANDPEACE.txt";
            Console.WriteLine("Лабораторную работу выполнил студент 1 курса , группа РПИа-о22, Ершов Владислав Олегович");
            string? writtenWord = "стол";

            Stopwatch stopwatch = new();
            stopwatch.Start();
            writtenWord = writtenWord.Length >= 3 ? writtenWord : null;
            List<string> wordsList = new();
            List<int> wordsCount = new();

            using (StreamReader reader = new(path))
            {
                string? line;
                // читаем файл построчно
                while ((line = reader.ReadLine()) != null)
                {
                    // разбиваем строку на слова, используя пробел как разделитель
                    string[] words = line.Split(' ');

                    //  выводим каждое слово на экран
                    foreach (string word in words)
                    {
                        if (CheckContains(word, writtenWord) && word.Length > 1)
                        {
                            Console.WriteLine(word);
                            if (wordsList.Contains(word))
                            {
                                
                                wordsCount[wordsList.IndexOf(word)]++;

                            }
                            else
                            {
                                wordsList.Add(word);
                                wordsCount.Add(1);
                            }

                        }
                    }         
                }
            }
           
            // создаем пары элементов массивов string и int
            var pairs = wordsList.Zip(wordsCount, (s, i) => new { str = s, num = i });

            var sortedPairs = pairs.OrderByDescending(p => p.num);

            // извлекаем отсортированные массивы string и int
            string[] sortedStrings = sortedPairs.Select(p => p.str).ToArray();
            int[] sortedInts = sortedPairs.Select(p => p.num).ToArray();

            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} миллисекунд");
            for (int i = 0; i < wordsCount.Count; i++)
            {
                Console.Write("слово ''" + sortedStrings[i] + "'' встречается в тексте ");
                Console.WriteLine(sortedInts[i] + " раз");
            }
    }
}
}