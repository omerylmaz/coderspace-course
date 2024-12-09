
#region Uzun süre alan bir işlemi eşzamanlı ve asenkron olarak gerçekleştiren iki farklı metot yazın.
// Bu örnekte şöyle bir senaryo yapmaya çalıştım, bir kullanıcı bir film uygulaması üzerinden bir filmi indirip izleyebilmesi senkron desteklenen bir senaryo yaptım başta
// Mesela filmi izlemek için önce indiriliyor daha sonrasında ise onu izliyoruz bu şekilde 12 sn geçti.
// Bir diğer senaryo ise bu site üzerinden filme yeni bir uygulama gelmiş ve artık kullanıcı filmi indirirken aynı zamanda inen filmi izleyebiliyorda.
// Bu şekilde 7 sn sürdü işlemler asenkron gerçekleştiği için.
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

// Senkron işlemler
Console.WriteLine("Syncrhonous process started");
Console.WriteLine("Movie download and watching process");
stopwatch.Start();
DownloadMovieSync();
WatchMovieSync();
stopwatch.Stop();
Console.WriteLine($"Process completed. Time: {stopwatch.Elapsed.TotalSeconds}");

stopwatch.Reset();



// Asenkron işlemler
Console.WriteLine("Asyncrhonous process started");
stopwatch.Start();
Task downloadTask = DownloadMovieAsync();
Task watchTask = WatchMovieAsync();

await Task.WhenAll(downloadTask, watchTask);
stopwatch.Stop();
Console.WriteLine($"Process completed. Time: {stopwatch.Elapsed.TotalSeconds}");

// Senkron metotlar

static void DownloadMovieSync()
{
    Console.WriteLine("Downloading...");
    Thread.Sleep(5000);
    Console.WriteLine("Downloaded");
}

static void WatchMovieSync()
{
    Console.WriteLine("Watching movie...");
    Thread.Sleep(7000);
    Console.WriteLine("Movie finished");
}

// Asenkron metotlar

static async Task DownloadMovieAsync()
{
    Console.WriteLine("Downloading...");
    await Task.Delay(5000);
    Console.WriteLine("Downloaded");
}

static async Task WatchMovieAsync()
{
    Console.WriteLine("Watching movie...");
    await Task.Delay(7000);
    Console.WriteLine("Movie finished");
}


#endregion


#region Task sınıfının tüm static methodları örnek senaryolar ile açıklayın.
static async Task GetUserData(int id)
{
    HttpClient client = new HttpClient();
    try
    {
        HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response: {responseBody}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occured: {ex.Message}");
    }
}

#region Task.Run
// Task.Run metodu arka planda ana thread'i bozmadan başka bir thread üzerinden işlem yapılmasını sağlar.
await Task.Run(() => GetUserData(40));
Console.WriteLine($"Api call ended");

#endregion

#region Task.StartNew
// Task.Run fonksiyonuna benzer fakat ekstra ayarlamalar ile daha CPU yükü gerektiren işlemlerde ek konfigürasyon amacı kullanılabilir.
// 
Task task = Task.Factory.StartNew(() => {
    GetUserData(1);
});
#endregion

#region Task.WaitAll
// Parametre olarak girilen tüm taskların işlemlerinin tamamlanmasını bekler.
Task task1 = Task.Run(() => GetUserData(1));
Task task2 = Task.Run(() => GetUserData(2));
Task.WaitAll(task1, task2);  // Eğer bu metodu koymasaydık önce apiye giden isteğin tamamnlandığı yazardı daha sonra apiye istek giderdi, bu da tutarsızlığa sebep olurdu.
Console.WriteLine("API call ended");
#endregion

#region Task.WhenAll
// Parametre olarak girilen tüm taskların işlemlerinin tamamlanması ile beraber geriye bir Task döndürür. Geriye bir task döndürmesi de bunun aslında bir asenkron işlem 
// olduğunu gösteriyor, yani Task.WaitAll metodunda iken taskların bitmesinin beklenmesi ana thread üzerinde gerçekleşiyordu. Fakat burada task'ların işlemlerinin bitmesi
// ayrı bir thread üzerinde gerçekleşiyor.
Task task3 = Task.Run(() => GetUserData(1));
Task task4 = Task.Run(() => GetUserData(2));
await Task.WhenAll(task3, task4);  // Eğer ki task'ı sade hali ile WhenAll olarak yazarsak api isteğinin bittiği mesajı yine önceden gelir. await le bekletebiliriz ya da farklı bir metot ile task'ın bitmesini bekleyebiliriz.
Console.WriteLine("Api call ended");
#endregion

#region Task.WaitAny
// Parametre olarak girilen task'lardan en az biri bittiği zaman devam eden task'tır. Bu bekleme işlemini ana thread üzerinde gerçekleştirir. Yani işlem senkrondur
Task task5 = Task.Run(() => GetUserData(1));
Task task6 = Task.Run(() => GetUserData(2));
Task.WaitAny(task5, task6);  // Task'lardan herhangi birinin bitmesini bekliyoruz
Console.WriteLine("Api call started and waiting to result all");
#endregion

#region Task.WhenAny
// Parametre olarak girilen task'lardan en az biri bittiği zaman devam eden task'tır. Bu bekleme işlemini farklı bir thread üzerinde gerçekleştirir. Yani işlem asenkrondur
Task task7 = Task.Run(() => GetUserData(1));
Task task8 = Task.Run(() => GetUserData(2));
await Task.WhenAny(task5, task6);  // Task'lardan herhangi birinin bitmesini bekliyoruz
Console.WriteLine("Api call started and waiting to result all");
#endregion

#region Task.Delay
// Belirli bir süre boyunca thread'i bekleten metottur
Task task9 = Task.Run(() => GetUserData(1));
await Task.Delay(1000);
Task task10 = Task.Run(() => GetUserData(2));
#endregion

#region Task.FromCanceled
// Task.FromCanceled, iptal edilmiş bir Task oluşturmak için kullanılır. Mesela bu örnek açısından aynı GetUserData metodunu cancellation token mantığını da koyup aşağıda 
// tekrar yazdım
static async Task GetUserDataWithCancelled(int id, CancellationToken cancellationToken)
{
    HttpClient client = new();


    try
    {
        cancellationToken.ThrowIfCancellationRequested(); // cancellation iptal edilirse hata fırlatılıyor

        HttpResponseMessage response = await client.GetAsync(
            $"https://jsonplaceholder.typicode.com/posts/{id}",
            cancellationToken);

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response: {response}");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Process canceled.");
        throw;
    }

}

CancellationTokenSource cts = new CancellationTokenSource();

try
{
    // İptal işlemini tetiklemek için 2 milisaniye sonra iptal ediyorun
    cts.CancelAfter(2000);

    // Api çağrısı başlatıyorum
    await GetUserDataWithCancelled(1, cts.Token);
}
catch (OperationCanceledException)
{
    var canceledTask = Task.FromCanceled(cts.Token);
    Console.WriteLine("Api call unsuccessfull.");
}
#endregion


#region Task.FromException
// Eğer ki task bir işlem gerçekleştireceksek ve ilgili kod bloğunun içinde uygun olmayan bir değer varsa hatayı Task.FromException olarak fırlatabiliriz
int id = -1;
Task validationTask;
if (id <= 0)
{
    validationTask = Task.FromException(new Exception("Invalid id"));
}
else
{
    validationTask = GetUserData(id);
}


await validationTask;


#endregion

#region Task.FromResult
// Task.FromResult sonuç olarak Task göndermek için kullanılır. Asenkron metot gibi görünen ancak senkron bir sonuç döndürmek istediğimiz durumlarda kullanılabilir.
static Task<bool> GetDataWithValidate(int id)
{
    if (id <= 0)
        return Task.FromResult(false);
    GetUserData(id);
    return Task.FromResult(true);
}

await GetDataWithValidate(-1);

#endregion


#region Task.Yield
//// Task.Yield çok aman aman örneğine denk gelmesemde araştırdığım kadarıyla bir task eğer çok işlem alıyorsa kendisinin ana thread'i bloke etmemesi için
//// kendisinin arka plana attırıp önceliği diğer işlemlere bırakıyor. Mesela bir işlem yapılıyor fakat bunun yüzünden UI tarafı donuyor sürekli, bu durumda
//// işi ara ara mola verdirerek UI daki diğer işlemlerin kitlenmesini önlerç

async Task Calculate()
{
    for (int i = 0; i < 100000; i++)
    {
        if (i % 1000 == 0)
        {
            // UI olmadığı sürece örnek vermek biraz zor, internetten bulduğum kadarıyla burada
            // belli periyotlarla arada bir görevi diğer işlemlere bırakıyoruz ki UI arada kitli kalmasın
            await Task.Yield();
        }
    }
}

#endregion

#region Task.GetAwaiter()
// Normalde Task'ın sonucuna ulaşmak istediğimizde ve senkron olarak o sonucu elde etmek istediğimizde GetAwaiter().GetResult() kullanabiliriz.

var response = GetUserDataWithResponse(1);
Console.WriteLine(response.GetAwaiter().GetResult());  // Bu şekilde bu kod aşamasında ilgili sonuç senkron olarak beklenip işlem bittikten sonrasında geriye sonucu gönderir
static async Task<string> GetUserDataWithResponse(int id)
{
    string responseBody = string.Empty;

    HttpClient client = new HttpClient();


    try
    {
        HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");


        responseBody = await response.Content.ReadAsStringAsync();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occured: {ex.Message}");
    }

    return responseBody;

}
#endregion

#endregion


#region Asenkron bir işlemi async/await yapısıyla kodlayın. İşlem sırasında hata yönetimini de ekleyin.

try
{
    string apiUrl = "https://jsonplaceholder.typicode.com/posts/1";

    string responseMessage = await SendGetRequestAsync(apiUrl);

    Console.WriteLine($"Response: {response}");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"HTTP Request Exception: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}

static async Task<string> SendGetRequestAsync(string url)
{
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);


        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Request is not successfull.");
        }

        return await response.Content.ReadAsStringAsync();
    }
}

#endregion

Console.ReadLine();