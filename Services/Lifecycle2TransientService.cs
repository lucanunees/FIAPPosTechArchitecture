namespace ProjetoInicial.Services;

public class Lifecycle2TransientService : ILifecycleTransientService
{
    private readonly ILifecycleTransientService _lifecycleService;

    public Lifecycle2TransientService(ILifecycleTransientService lifeCycleService)
    {
        _lifecycleService = lifeCycleService;
    } 

    public DateTime DataAtual() => _lifecycleService.DataAtual();
}
