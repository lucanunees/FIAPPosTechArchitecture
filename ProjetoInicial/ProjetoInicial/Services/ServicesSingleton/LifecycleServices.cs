namespace ProjetoInicial.Services.ServicesSingleton;

public class LifecycleServices : ILifecycleService
{
    private readonly DateTime _date = DateTime.Now;

    public DateTime DataAtual() => _date; 
}
