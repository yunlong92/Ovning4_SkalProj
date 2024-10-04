using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("\nEnter '+' to add an item, '-' to remove an item, or 'exit' to return to the main menu:");
                string input = Console.ReadLine()!;

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (input.Length > 1)
                {
                    char nav = input[0];
                    string value = input.Substring(1).Trim();

                    switch (nav)
                    {
                        case '+':
                            theList.Add(value);
                            Console.WriteLine($"Added: {value}");
                            break;

                        case '-':
                            if (theList.Contains(value))
                            {
                                theList.Remove(value);
                                Console.WriteLine($"Removed: {value}");
                            }
                            else
                            {
                                Console.WriteLine($"{value} not found in the list.");
                            }
                            break;

                        default:
                            Console.WriteLine("Please use '+' to add or '-' to remove an item.");
                            break;
                    }

                    // Display list count and capacity after every operation
                    Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid command (e.g., '+Adam' or '-Adam').");
                }
            }
        }

        // 2. När ökar listans kapacitet?
        // Kapaciteten ökar när antalet element överstiger den nuvarande kapaciteten.
        // 
        // 3. Med hur mycket ökar kapaciteten?
        // Kapaciteten fördubblas när den nås.
        // 
        // 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        // För att undvika frekventa minnesallokeringar, vilket förbättrar prestandan.
        // 
        // 5. Minskar kapaciteten när element tas bort ur listan?
        // Nej, kapaciteten förblir densamma tills man explicit trimmar listan.
        // 
        // 6. När är det fördelaktigt att använda en egendefinierad array istället för en lista?
        // När du vet antalet element i förväg eller när minnesanvändning och prestanda är avgörande.

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nQueue Simulation:");
                Console.WriteLine("Enter '+' followed by a name to add a person to the queue (e.g., +Kalle),");
                Console.WriteLine("'-' to dequeue the next person, or 'exit' to return to the main menu:");
                string input = Console.ReadLine()!;

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (input.Length > 0)
                {
                    char action = input[0]; // The action, either + or -
                    string name = input.Length > 1 ? input.Substring(1).Trim() : "";

                    switch (action)
                    {
                        case '+':
                            // Add a person to the queue
                            if (!string.IsNullOrEmpty(name))
                            {
                                queue.Enqueue(name);
                                Console.WriteLine($"{name} has joined the queue.");
                            }
                            else
                            {
                                Console.WriteLine("Please enter a name after '+' to add a person to the queue.");
                            }
                            break;

                        case '-':
                            // Remove the first person in the queue
                            if (queue.Count > 0)
                            {
                                string dequeuedPerson = queue.Dequeue();
                                Console.WriteLine($"{dequeuedPerson} has been served and left the queue.");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty. No one to serve.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input. Use '+' to add a person or '-' to remove a person.");
                            break;
                    }

                    // Show the current state of the queue
                    Console.WriteLine("Current queue:");
                    foreach (var person in queue)
                    {
                        Console.WriteLine(person);
                    }
                    Console.WriteLine($"Number of people in the queue: {queue.Count}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        // 1.Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det inte så smart att använda en stack i det här fallet?
        // För att den som kommer sist i kön blir servad först. Vilket inte stämmer med kösystem.

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:"
                                + "\n1. Reverse a string"
                                + "\n0. Exit to main menu");

                char choice = Console.ReadLine()![0];

                switch (choice)
                {
                    case '1':
                        ReverseText();
                        break;
                    case '0':
                        return; // Exit the method, return to main menu
                    default:
                        Console.WriteLine("Please enter a valid option (1 or 0)");
                        break;
                }
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter a string to reverse:");
            string input = Console.ReadLine()!;

            Stack<char> stack = new Stack<char>();

            // Push each character of the string onto the stack
            foreach (char c in input)
            {
                stack.Push(c);
            }

            // Pop each character off the stack to reverse the string
            string reversed = "";
            while (stack.Count > 0)
            {
                reversed += stack.Pop();
            }

            Console.WriteLine($"Reversed string: {reversed}");
        }


        static void CheckParanthesis()
        {
            Console.WriteLine("Enter a string to check for balanced parentheses:");
            string input = Console.ReadLine()!;

            // Stack to keep track of opening parentheses
            Stack<char> stack = new Stack<char>();

            // Dictionary to match opening and closing parentheses
            Dictionary<char, char> matchingParentheses = new Dictionary<char, char>()
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' }
    };

            foreach (char c in input)
            {
                // If it's an opening parenthesis, push to the stack
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // If it's a closing parenthesis, check if it matches the top of the stack
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Check if stack is empty or the top element doesn't match
                    if (stack.Count == 0 || stack.Peek() != matchingParentheses[c])
                    {
                        Console.WriteLine("The string is not well-formed.");
                        return;
                    }
                    else
                    {
                        // Pop the matching opening parenthesis
                        stack.Pop();
                    }
                }
            }

            // If the stack is empty, all parentheses were matched
            if (stack.Count == 0)
            {
                Console.WriteLine("The string is well-formed.");
            }
            else
            {
                Console.WriteLine("The string is not well-formed.");
            }
        }

        // 1.Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper.Du ska använda dig av någon eller några av de datastrukturer vi precis gått igenom.Vilken datastruktur använder du?
        // En stack eftersom vi behöver hålla reda på vilken ordning parenteserna öppnas och stängs i, och en stack gör detta på ett effektivt och naturligt sätt med LIFO-strukturen.

    }
}



// 1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
// Stacken är boxar som är staplade på varandra där vi använder innehållet i översta boxen. För att komma åt den undre måste ovanstående box lyftas av.
// Heapen är en form av struktur där allt är tillgänglig med enkel åtkomst. växer på ett mer dynamiskt och osystematiskt sätt beroende på hur minnet allokeras och frigörs.

// 2.Vad är Value Types respektive Reference Types och vad skiljer dem åt?
// De skiljer sig åt i hur de hanterar och lagrar data i minnet. En reference type lagras alltid på heapen. Medan Value types, lagras där de deklareras. Alltså kan value types lagras både på stacken eller heapen. 

// 3.Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför? 
// Eftersom int är en värdetyp, så kopieras bara värdet av x till y. När y ändras, påverkas inte x. Därför returnerar den 3. Eftersom MyInt är en referenstyp, både x och y refererar till samma objekt i minnet. Ändringar i y.MyValue påverkar också x.MyValue, eftersom de delar samma objekt. Därför returnerar den 4.
