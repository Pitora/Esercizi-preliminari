namespace ConsoleApp
{
    public class Receiver
    {
        protected string _name;
        bool power;
        static int page_limit = 20;
        protected int current_line;
        protected int current_page;
        protected List<string[]> pages;


        public Receiver(string name)
        {
            _name = name;
            power = false;
            current_line = -1;
            current_page = -1;
            pages = new List<string[]>();
        }

        public string getName(){return _name;}

        public void NewPage(int lines)
        {
            pages.Add(new string[lines]);
            current_page++;
            current_line = 0;
        }

        public void Acquire(string[] page)
        {
            if (current_page == -1)
            {
                NewPage(page_limit);
            }
            for (int i = 0; i < page.Length; i++)
            {
                if (current_line + i < pages[current_page].Length)
                {
                    pages[current_page][current_line + i] = page[i];
                }
                else
                {
                    Console.WriteLine("Reached page limit. Please, add a new page.");
                }
            }
            current_line += page.Length;
            Print();
        }

        public virtual void Print()
        {
            Console.WriteLine($"\n{_name} is printing");
            for (int i = 0; i <= current_page; i++)
            {
                Console.WriteLine($"\nPrinting page {i}:");
                for (int j = 0; j < pages[i].Length; j++)
                {
                    Console.WriteLine(pages[i][j]);
                }
            }
            Console.WriteLine($"\n{_name} ended printing \n");
        }

        public void Remove(int page_length)
        {
            for (int i = 0; i < page_length; i++)
            {
                current_line--;
                pages[current_page][current_line] = "";
            }
        }

        public void RemoveLastPage()
        {
            if (pages.Count > 0)
            {
                pages.RemoveAt(pages.Count - 1);
                current_page--;
            }
            else
            {
                Console.WriteLine("There are no pages.");
            }
        }

        public void Switch()
        {
            power = !power;
            if (power)
            {
                Console.WriteLine($"{_name} ON");
            }
            else
            {
                Console.WriteLine($"{_name} OFF");
            }
        }

    }
}