using System;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers(int score)
    {
        _observers.ForEach((_observers) =>
        {
            _observers.Notify();
        });
    }
}

public interface IObserver
{
    public void Notify();


}