namespace ProjetoInicial.Services.ServicesSingleton;

public class Lifecycle2Services : ILifecycleService
{
    private readonly ILifecycleService _lifecycleService;

    public Lifecycle2Services(ILifecycleService lifeCycleService)
    {
        _lifecycleService = lifeCycleService;
    } 

    public DateTime DataAtual() => _lifecycleService.DataAtual();
}
