using System;

namespace SingletonPattern;

public class ApplicationContext : Singleton<ApplicationContext>
{
    public string Logged { get; set; }
    public DateTime LoggedOn { get; set; }
    
    // Zła praktyka! Antywzorzec
    public int SelectedCustomerId { get; set; }
    public int SelectedOrderId { get; set; }
}
