// Kako biste proverili izvrsavanje otkomentarisite poziv metode za odgovarajuci zadatak

//Zadatak1();
//Zadatak2();
//Zadatak3();
//Zadatak5();
//Zadatak6();

/* 1. Napraviti konzolnu aplikaciju koja će se ponašati kao kalkulator za množenje, gde će od korisnika
primati brojeve i ispisivaće njegov kvadrat sve dok korisnik ne unese "x" u kom momentu aplikacija
traba da završi sa radom. */

void Zadatak1()
{
    Console.WriteLine("Za prekid rada aplikacije uneti 'x'");
    while (true)
    {
        Console.WriteLine("Broj za kvadriranje: ");

        var input = Console.ReadLine();
        float parsedInput;
        while (!float.TryParse(input, out parsedInput))
        {
            if (input?.ToUpper() == "X")
                return;

            Console.WriteLine("Niste uneli broj! Pokusajte ponovo: ");
            input = Console.ReadLine();
        }

        Console.WriteLine(parsedInput * parsedInput);
    }
}

/* 2. Napraviti konzolnu aplikaciju koja od korisnika traži pozitivan broj n i ispisuje n brojeva u
fibonačijevom nizu. */

void Zadatak2()
{
    Console.WriteLine("Unesite pozitivan celi broj: ");
    var input = Console.ReadLine();
    int parsedInput;
    while (!int.TryParse(input, out parsedInput) || parsedInput <= 0)
    {
        Console.WriteLine("Niste uneli pozitivan celi broj! Pokusajte ponovo: ");
        input = Console.ReadLine();
    }

    int first = 0;
    int second = 1;
    string output = parsedInput == 1 ? "0" : "0, 1";
        
    for ( int i = 2; i < parsedInput; i++ )
    {
        second = first + second;
        first = second - first;
        output += ", " + second;
    }

    Console.WriteLine(output);
}

/* 3. Iz liste brojeva numbers prikazati brojeve koji su deljivi sa brojem n koji unosimo preko konzole
 Za inicijalizaciju liste brojeva koristiti ugradjenu funkciju Enumerable.Range(start, count) koja
vraca "count" brojeva pocev od "start". */

void Zadatak3()
{
    var numbers = Enumerable.Range(1, 50);

    Console.WriteLine("Unesite broj za proveru deljivosti: ");
    var input = Console.ReadLine();
    int parsedInput;
    while (!int.TryParse(input, out parsedInput) || parsedInput == 0)
    {
        Console.WriteLine("Niste celi broj, ili ste uneli 0! Pokusajte ponovo: ");
        input = Console.ReadLine();
    }

    Console.WriteLine("Brojevi koji su celobrojno deljivi sa {0}: ", parsedInput);
    var result = numbers.Where(num => num % parsedInput == 0);
    foreach(var num in result)
    {
        Console.Write("{0} ", num);
    }
}

/*  5. Za kolekciju objekata tipa "Osoba" iz zadatka 4 napisati LINQ upit koji vraca
 listu osoba soritranih po broju godina, opadajuce. */

void Zadatak5()
{
    var people = new List<Osoba>()
    {
        new Osoba("Ana", 35, Pol.Zensko),
        new Osoba("Petar", 25, Pol.Musko),
        new Osoba("Mirko", 23, Pol.Musko),
        new Osoba("Helena", 27, Pol.Zensko),
        new Osoba("Boban", 38, Pol.Musko),
        new Osoba("Nikola", 56, Pol.Musko),
        new Osoba("Jelena", 19, Pol.Zensko),
        new Osoba("Svetlana", 45, Pol.Zensko),
    };

    var result = people.OrderByDescending(person => person.Starost);
    foreach(var person in result)
    {
        Console.WriteLine(person);
    }
}

/*  6. Za kolekciju objekata tipa "Osoba" iz zadatka 4 napisati LINQ upit koji vraca
 imena i godine osoba grupisanih po polu osobe. */

void Zadatak6()
{
    var people = new List<Osoba>()
    {
        new Osoba("Ana", 35, Pol.Zensko),
        new Osoba("Petar", 25, Pol.Musko),
        new Osoba("Mirko", 23, Pol.Musko),
        new Osoba("Helena", 27, Pol.Zensko),
        new Osoba("Boban", 38, Pol.Musko),
        new Osoba("Nikola", 56, Pol.Musko),
        new Osoba("Jelena", 19, Pol.Zensko),
        new Osoba("Svetlana", 45, Pol.Zensko),
    };

    var result = people.GroupBy(person => person.Pol);
    foreach(var group in result)
    {
        Console.WriteLine(group.Key);
        foreach(var person in group)
        {
            Console.WriteLine("Ime: {0}, Starost: {1}", person.Ime, person.Starost);
        }
    }

}

/* 4. Kreirati klasu "Osoba" koja sadrzi polja koja oznacavaju ime, starost i pol osobe.
 Pol implementirati kao enum. */

class Osoba
{
    public string Ime { get; set; }
    public int Starost { get; set; }
    public Pol Pol { get; set; }
    
    public Osoba(string Ime, int Starost, Pol Pol)
    {
        this.Ime = Ime;
        this.Starost = Starost;
        this.Pol = Pol;
    }

    public override string ToString()
    {
        return string.Format("Ime: {0}, Starost: {1}, Pol: {2}", Ime, Starost, Pol);
    }
}

enum Pol
{
    Musko, 
    Zensko
}

