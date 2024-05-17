using Stateless;
using System.Diagnostics;

namespace StateMachinePattern;

// dotnet add package Stateless

// Wzorzec Proxy
// wariant klasowy
public class OrderProxy : Order
{
    private readonly StateMachine<OrderStatus, OrderTrigger> _machine;

    public OrderProxy(OrderStatus orderStatus = OrderStatus.Pending)
        : base(orderStatus)
    {
        _machine = new StateMachine<OrderStatus, OrderTrigger>(orderStatus);

        _machine.Configure(OrderStatus.Pending)            
            .PermitIf(OrderTrigger.Confirm, OrderStatus.Processing, () => IsPaid)
            .PermitReentryIf(OrderTrigger.Confirm, () => !IsPaid && TryPaidCounter < 2)
            .PermitIf(OrderTrigger.Confirm, OrderStatus.Canceled, () => !IsPaid && TryPaidCounter >= 2)
            .Permit(OrderTrigger.Cancel, OrderStatus.Canceled)
            .OnExit(() => TryPaidCounter++);
            

        _machine.Configure(OrderStatus.Processing)
            .Permit(OrderTrigger.Confirm, OrderStatus.Completed)
            .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

        // Wyświetlanie przejść podczas działania maszyny
        _machine.OnTransitioned(transition => Debug.WriteLine($"{DateTime.Now} {transition.Trigger} : {transition.Source} -> {transition.Destination}"));
    }


    public string Graph => Stateless.Graph.UmlDotGraph.Format(_machine.GetInfo());

    public override OrderStatus Status => _machine.State;
    public override void Confirm() => _machine.Fire(OrderTrigger.Confirm);
    public override void Cancel() => _machine.Fire(OrderTrigger.Cancel);
}
