using System;
using System.Windows.Forms;

public static class ControlExtensions
{
    public static void InvokeAuto(this Control control, Action action)
    {
        if (control.InvokeRequired)
            control.Invoke((MethodInvoker)(() => action()));
        else
            action.Invoke();
    }
}