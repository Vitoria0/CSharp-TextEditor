using System;
using System.IO;

namespace textEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Qual operação deseja realizar?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Open();
                    break;
                case 2:
                    Edit();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual arquivo deseja abrir?");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                using (var file = new StreamReader(path))
                {
                    Console.Clear();
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione Enter para voltar ao menu...");
            Console.ReadLine();
            Menu();
        }

        public static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo que deseja editar:");
            string path = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo (pressione ESC para sair e salvar):");
            Console.WriteLine("-------------------------");
            string text = "";

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                Console.Write(keyInfo.KeyChar);
                text += keyInfo.KeyChar;
            }

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine("\n\nTexto salvo com sucesso.");
            Console.WriteLine("Pressione Enter para voltar ao menu...");
            Console.ReadLine();
            Menu();
        }
    }
}
