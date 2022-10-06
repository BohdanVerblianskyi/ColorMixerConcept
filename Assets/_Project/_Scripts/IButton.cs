using System;

public interface IButton
{
    Action OnClick { get; set; }
}