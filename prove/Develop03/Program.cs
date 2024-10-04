using System;
using System.Collections.Generic;

namespace ScriptureMemorizerApp
{
    
    class Word
    {
        private string _text;
        private bool _isHidden;

        
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

       
        public void Hide()
        {
            _isHidden = true;
        }

       
        public void Show()
        {
            _isHidden = false;
        }

        
        public override string ToString()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            return _text;
        }
    }

    
    class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;

        
        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        
        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        
        public override string ToString()
        {
            if (_startVerse == _endVerse)
                return $"{_book} {_chapter}:{_startVerse}";
            else
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }

    
    class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;

       
        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            
            string[] wordsArray = text.Split(' ');
            foreach (var word in wordsArray)
            {
                _words.Add(new Word(word));
            }
        }

        
        public ScriptureReference GetReference()
        {
            return _reference;
        }

        
        public void HideRandomWords(int numWords)
        {
            Random rand = new Random();
            List<int> hiddenIndices = new List<int>();

            
            while (hiddenIndices.Count < numWords && hiddenIndices.Count < _words.Count)
            {
                int index = rand.Next(0, _words.Count);
                if (!hiddenIndices.Contains(index))
                {
                    _words[index].Hide();
                    hiddenIndices.Add(index);
                }
            }
        }

        
        public override string ToString()
        {
            List<string> wordList = new List<string>();
            foreach (Word word in _words)
            {
                wordList.Add(word.ToString());
            }
            string hiddenText = string.Join(" ", wordList);
            return $"{_reference}: {hiddenText}";
        }
    }

    
    class ScriptureMemorizer
    {
        private Scripture _scripture;

        
        public ScriptureMemorizer(Scripture scripture)
        {
            _scripture = scripture;
        }

        
        public void DisplayScripture()
        {
            Console.WriteLine(_scripture.ToString());
        }

       
        public void Memorize()
        {
            while (true)
            {
                DisplayScripture();

                Console.WriteLine("Press Enter to hide more words or type 'done' to finish: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

                
                _scripture.HideRandomWords(3);
            }
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            // Create a ScriptureReference object for a single verse (John 3:16)
            ScriptureReference reference = new ScriptureReference("John", 3, 16);

            // Or create a ScriptureReference object for a verse range (Proverbs 3:5-6)
            // ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);

            // Sample scripture text
            string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

            // Create a Scripture object
            Scripture scripture = new Scripture(reference, text);

            // Create a ScriptureMemorizer object
            ScriptureMemorizer memorizer = new ScriptureMemorizer(scripture);

            // Start the memorization process
            memorizer.Memorize();
        }
    }
}
