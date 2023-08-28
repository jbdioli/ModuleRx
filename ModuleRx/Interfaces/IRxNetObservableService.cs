namespace ModuleRx.Interfaces;

public interface IRxNetObservableService
{
    public void SendData<T>(T data);
}