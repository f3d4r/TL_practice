public class Program


{
    public static void Main( string[] args )
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        Console.Write( "Введите название файла-cловарая (в формате <file.txt>): " );
        string fileName = Console.ReadLine();

        if ( !File.Exists( fileName ) )
        {
            Console.WriteLine( $"Ошибка: файла {fileName} не существует" );
            return;
        }

        FileParse( fileName, dictionary );

        while ( true )
        {
            Console.WriteLine( "1.Добавление нового слова" );
            Console.WriteLine( "2.Перевод с английского на русский" );
            Console.WriteLine( "3.Перевод с русского на английский" );
            Console.WriteLine( "4.Выход" );
            Console.Write( "Выберите действие: " );

            string choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    AddWord( fileName, dictionary );
                    break;
                case "2":
                    TranslateEngToRus( fileName, dictionary );
                    break;
                case "3":
                    TranslateRusToEng( fileName, dictionary );
                    break;
                case "4":
                    Console.WriteLine( "Выход..." );
                    return;
                default:
                    Console.WriteLine( "Неверный ввод. Пожалуйста, введите значения от 1 до 4" );
                    break;
            }
            Console.WriteLine();
        }
    }

    static void FileParse( string fileName, Dictionary<string, string> dictionary )
    {
        if ( File.Exists( fileName ) )
        {
            if ( fileName.Length != 0 )
            {
                foreach ( string line in File.ReadLines( fileName ) )
                {
                    string firstWord = line.Split( ':' )[ 0 ];
                    string secondWord = line.Split( ':' )[ 1 ];

                    dictionary.Add( firstWord, secondWord );
                }
            }
            else
            {
                Console.WriteLine( "Файл пустой" );
            }
        }
        else
        {
            Console.WriteLine( $"Ошибка: файла {fileName} не существует" );
        }
    }

    static void AddWord( string fileName, Dictionary<string, string> dictionary )
    {
        Console.Write( "Добавьте слово на английском: " );
        string engWord = Console.ReadLine();

        Console.Write( "Добавьте перевод слова: " );
        string rusWord = Console.ReadLine();

        if ( !string.IsNullOrEmpty( engWord ) && !string.IsNullOrEmpty( rusWord ) )
        {
            dictionary.Add( engWord, rusWord );
            File.AppendAllText( fileName, $"{engWord}:{rusWord}\n" );
        }
        else
        {
            Console.WriteLine( "Поля не могут быть пустыми" );
        }
    }

    static void TranslateEngToRus( string fileName, Dictionary<string, string> dictionary )
    {
        Console.Write( "Введите слово на английском: " );
        string searchWord = Console.ReadLine();

        if ( dictionary.TryGetValue( searchWord, out string translation ) )
        {
            Console.WriteLine( $"Перевод: {translation}" );
        }
        else
        {
            Console.Write( "Слово не найдено, хотите добавить новое слово в словарь? (введите 'y' для добавления, иначе — пропустить): " );
            string answer = Console.ReadLine();

            switch ( answer )
            {
                case "y":
                    AddWord( fileName, dictionary );
                    break;
                default:
                    Console.WriteLine( "Вы выбрали не добавлять слово" );
                    break;
            }
        }
    }

    static void TranslateRusToEng( string fileName, Dictionary<string, string> dictionary )
    {
        Console.Write( "Введите слово на русском: " );
        string searchWord = Console.ReadLine();

        string translate = null;
        foreach ( var pair in dictionary )
        {
            if ( pair.Value == searchWord )
            {
                translate = pair.Key;
                break;
            }
        }

        if ( translate != null )
        {
            Console.WriteLine( $"Перевод: {translate}" );
        }
        else
        {
            Console.Write( "Слово не найдено, хотите добавить новое слово в словарь? (введите 'y' для добавления, иначе — пропустить): " );
            string answer = Console.ReadLine();
            switch ( answer )
            {
                case "y":
                    AddWord( fileName, dictionary );
                    break;
                default:
                    Console.WriteLine( "Вы выбрали не добавлять слово" );
                    break;
            }
        }
    }
}