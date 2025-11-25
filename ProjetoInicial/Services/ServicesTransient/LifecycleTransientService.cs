namespace ProjetoInicial.Services.ServicesTransient;

public class LifecycleTransientService : ILifecycleTransientService
{
    private readonly DateTime _date = DateTime.Now;

    public DateTime DataAtual() => _date; 
}
