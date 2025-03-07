﻿using Content.Client._Horizon.Economy.ATM.UI;
using Content.Shared._Horizon.Economy.ATM;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.FixedPoint;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._Horizon.Economy.ATM;

public sealed class ATMBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private ATMMenu? _menu;

    public ATMBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }
    protected override void Open()
    {
        base.Open();
        _menu = new ATMMenu { Title = IoCManager.Resolve<IEntityManager>().GetComponent<MetaDataComponent>(Owner).EntityName };

        _menu.IdCardButton.OnPressed += _ => SendMessage(new ItemSlotButtonPressedEvent(AtmComponent.IdCardSlotId));
        _menu.OnWithdrawAttempt += OnWithdrawAttempt;

        _menu.OnClose += Close;
        _menu.OpenCentered();
    }
    private void OnWithdrawAttempt(LineEdit.LineEditEventArgs args, FixedPoint2 amount)
    {
        SendMessage(new ATMRequestWithdrawMessage(amount, args.Text));
    }


    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        if (_menu == null)
            return;

        if (state is AtmBoundUserInterfaceState cast)
        {
            _menu.UpdateState(cast);
        }
        else if (state is AtmBoundUserInterfaceBalanceState cast2)
        {
            _menu.UpdateBalanceState(cast2);
        }
    }
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing)
            return;

        if (_menu == null)
            return;

        _menu.OnClose -= Close;
        _menu.Dispose();
    }
}
