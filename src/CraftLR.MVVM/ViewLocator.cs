using System;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using CraftLR.MVVM.ViewModels;

namespace CraftLR.MVVM;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        if (data is not null)
        {
            string name = data.GetType().FullName!.Replace("ViewModel", "View");
            Type? type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        return new TextBlock { Text = "Data is null " };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}