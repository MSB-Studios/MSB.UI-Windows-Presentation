﻿namespace MSB
{
    /// <summary>
    /// Represents a method that handles general events.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender.</typeparam>
    /// <param name="sender">The event source.</param>
    /// <param name="args">The event data. If there is no event data, this parameter will be <see langword="null"/>.</param>
    public delegate void TypedEventHandler<TSender> (TSender sender, object args = null);

    /// <summary>
    /// Represents a method that handles general events.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender.</typeparam>
    /// <typeparam name="TEventArgs">The type of the event data generated by the event.</typeparam>
    /// <param name="sender">The event source.</param>
    /// <param name="args">The event data. If there is no event data, this parameter will be <see langword="default"/>.</param>
    public delegate void TypedEventHandler<TSender, TEventArgs>(TSender sender, TEventArgs args = default);
}
