
//Eski ve klasik yöntem.

using SwitchExpressions;

switch (DateTime.Now.DayOfWeek)
{
    case DayOfWeek.Sunday:
        Console.WriteLine("Pazar");
        break;
    case DayOfWeek.Monday:
        Console.WriteLine("Pazartesi");
        break;
    case DayOfWeek.Tuesday:
        Console.WriteLine("Salı");
        break;
    case DayOfWeek.Wednesday:
        Console.WriteLine("Çarşamba");
        break;
    case DayOfWeek.Thursday:
        Console.WriteLine("Perşembe");
        break;
    case DayOfWeek.Friday:
        Console.WriteLine("Cuma");
        break;
    case DayOfWeek.Saturday:
        Console.WriteLine("Cumartesi");
        break;
    default:
        Console.WriteLine("Gün Belirtilmedi");
        break;
}


//Yeni yöntem.

string day = DateTime.Now.DayOfWeek switch
{
    DayOfWeek.Sunday => "Pazar",
    DayOfWeek.Monday => "Pazartesi",
    DayOfWeek.Tuesday => "Salı",
    DayOfWeek.Wednesday => "Çarşamba",
    DayOfWeek.Thursday => "Perşembe",
    DayOfWeek.Friday => "Cuma",
    DayOfWeek.Saturday => "Cumartesi",
    _ => "Gün belirtilmedi"
};

Console.WriteLine(day);



//Yeni yöntem when ile şart belirtmek

int number = 10;
string name = number switch
{
    var x when (x == 7 || x == 10) && x == 2 => "Emre Can",
    var x when x < 5 => "Ayar",
    int x when x == 10 => "Emre Can Ayar",
    int x when x == 9 && x % 2 == 1 => "Sonuç Yok",
    var x => "Hiçbiri"
};
Console.WriteLine(name);


//Tuple Patterns - Eski Yöntem

int n1 = 10;
int n2 = 20;
string message = "";
switch (n1, n2)
{
    case (5, 10):
        message = "5 ile 10 değerleri";
        break;
    case (10, 20):
        message = "10 ile 20 değerleri";
        break;
    default:
        message = "Girilen değerler belirtilen aralıklarda değildir.";
        break;
}
Console.WriteLine(message);


//Tuple Patterns - Yeni Yöntem
string returnMessage = (n1, n2) switch
{
    (5, 10) => "5 ile 10 değerleri",
    (10, 20) => "10 ile 20 değerleri",
    var x when x.n1 == 10 && x.n2 == 20 => "10 ile 20 değerleri",
    _ => "Girilen değerler belirtilen aralıklarda değildir."

};

Console.WriteLine(returnMessage);


//Property Patterns - Eski Yöntem

Employee employee = new Employee
{
    FirstName = "Emre Can",
    LastName = "Ayar",
    Job = "Yazılım Uzmanı",
};

double salary = 0;

switch (employee.Job)
{
    case "Analiz Uzmanı":
        salary = 50;
        break;
    case "Test Uzmanı":
        salary = 45;
        break;
    case "Yazılım Uzmanı":
        salary = 55;
        break;
    default:
        salary = 0;
        break;
}
Console.WriteLine(salary);



//Property Patterns - Yeni Yöntem

salary = employee switch
{
    { Job: "Analiz Uzmanı" } => 50,
    { Job: "Test Uzmanı" } => 45,
    { Job: "Yazılım Uzmanı" } => 55,
    var x when x.Job == "Müdür" => 60,
    _ => 0
};

Console.WriteLine(salary);